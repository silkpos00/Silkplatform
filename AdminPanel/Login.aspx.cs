using AdminPanel.classes;
using System;
using System.Web;
namespace AdminPanel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected  void btnSignIn_Click(object sender, EventArgs e)
        {
            lblMessage.Text=string.Empty;
            try
            {

                var requestData = new
                {
                    username = txtUsername.Text.Trim(),
                    password = txtPassword.Text.Trim()
                };
                var d = CallRestApi.SendRequest(requestData, ApiUrls.getAccessToken, "post");
                if (d.StatusCode == 200)
                {
                    var token = d.Data.data;
                   // lblMessage.Text = token;
                   // Session["token"] = token;
                    HttpCookie authCookie = new HttpCookie("AuthToken");
                    authCookie.Value = token;
                    authCookie.HttpOnly = false; 
                    authCookie.Expires = DateTime.Now.AddDays(1); 
                    if (Request.Cookies["AuthToken"] != null)
                    {
                        Response.Cookies.Remove("AuthToken");
                    }
                    Response.Cookies.Add(authCookie);
                    Response.Redirect("default.aspx");
                    // پردازش موفق
                }
                else if (d.StatusCode == 401)
                {
                    // کاربر مجاز نیست
                    lblMessage.Text =  d.error.message;
                }
                else if (d.StatusCode == 404)
                {
                    // سرویس پیدا نشد
                    lblMessage.Text = d.error.message;
                }
                else
                {
                    // سایر خطاها
                    string errorMsg = d.error ?? "خطایی رخ داده است.";
                    lblMessage.Text = errorMsg;
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}