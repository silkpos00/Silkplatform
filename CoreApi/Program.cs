using CoreApi.Middlewares;
using CoreApi.Model;
using CoreApi.Model.BackOffice;
using CoreApi.Model.BaseInfo;
using CoreApi.Model.MenuBuilder;
using CoreApi.Model.Order;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// کلید برای رمزنگاری
var jwtKey = builder.Configuration["Jwt:Key"] ?? "your_secret_key_123456789"; // ذخیره بهتر در appsettings.json
var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // اگر می‌خواهید Issuer را بررسی کنید true بگذارید
        ValidateAudience = false, // اگر می‌خواهید Audience را بررسی کنید true بگذارید
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Admin"));

    options.AddPolicy("Over18", policy =>
        policy.RequireAssertion(context =>
        {
            if (context.User.HasClaim(c => c.Type == "Age"))
            {
                var age = int.Parse(context.User.FindFirst("Age").Value);
                return age >= 18;
            }
            return false;
        }));
});
builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("PolicySilkpos", builder =>
{
    builder.WithOrigins("https://localhost:44350")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            //.AllowAnyOrigin()
                            .SetIsOriginAllowed(hostname => true);
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<RefreshTokenRepository>();
builder.Services.AddScoped<MenuBulderRepository>();
builder.Services.AddScoped<BackOfficeRepository>();
builder.Services.AddScoped<BaseInfoRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // تنظیم امنیت برای JWT
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter the JWT token as 'Bearer {token}'"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddHttpContextAccessor();

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .Enrich.WithClientIp()
    //.Enrich.WithClientAgent()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("cnn"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "SerilogLogs",
            AutoCreateSqlTable = false // چون خودمون جدول ساختیم
        },
    columnOptions: new ColumnOptions
    {
        AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn { ColumnName = "IpAddress", DataType = SqlDbType.NVarChar, DataLength = 50 },
        new SqlColumn { ColumnName = "UserId", DataType = SqlDbType.NVarChar, DataLength = 100 },
        new SqlColumn { ColumnName = "PortalId", DataType = SqlDbType.NVarChar, DataLength = 100 },
        new SqlColumn { ColumnName = "RequestBody", DataType = SqlDbType.NVarChar, DataLength = -1 }, // -1 برای NVARCHAR(MAX)
        new SqlColumn { ColumnName = "ResponseBody", DataType = SqlDbType.NVarChar, DataLength = -1 },
        new SqlColumn { ColumnName = "Path", DataType = SqlDbType.NVarChar, DataLength = 500 },
        new SqlColumn { ColumnName = "Method", DataType = SqlDbType.NVarChar, DataLength = 10 },
        new SqlColumn { ColumnName = "StatusCode", DataType = SqlDbType.Int }
    }
    },
        restrictedToMinimumLevel: LogEventLevel.Information
    )
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();
var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
