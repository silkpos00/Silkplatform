using AdminPanel.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserManuData();
            }
        }
        private void GetUserManuData()
        {
            HttpCookie authCookie = Request.Cookies["AuthToken"];
            if (authCookie != null)
            {
                string token = authCookie.Value;
                var d = CallRestApi.SendRequest(null, ApiUrls.GetUserMenu, "get", token); 
                var dataJson = Convert.ToString(d.Data.data);
                var menuItems = JsonConvert.DeserializeObject<List<UserMenuItem>>(dataJson);
                var menuTree = UserMenu.BuildMenuTree(menuItems);
                string html = UserMenu.GenerateMenuHtml(menuTree);
                LiteralMenu.Text = html;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            


        }
        private void GetUserManuData2()
        {
            try
            {

               
                var d = CallRestApi.SendRequest(null, ApiUrls.GetUserMenu, "get", Session["token"].ToString());
                if (d.StatusCode == 200)
                {
                    var token = d.Data.data;
                    // lblMessage.Text = token;
                    Session["token"] = token;
                    Response.Redirect("default.aspx");
                    // پردازش موفق
                }
                else if (d.StatusCode == 401)
                {
                    // کاربر مجاز نیست
                   // lblMessage.Text = d.error.message;
                }
                else if (d.StatusCode == 404)
                {
                    // سرویس پیدا نشد
                   // lblMessage.Text = d.error.message;
                }
                else
                {
                    // سایر خطاها
                    string errorMsg = d.error ?? "خطایی رخ داده است.";
                    //lblMessage.Text = errorMsg;
                }

            }
            catch (Exception ex)
            {

            }
        }
        

    }
}