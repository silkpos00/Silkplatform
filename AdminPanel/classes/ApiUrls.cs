using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AdminPanel.classes
{
    public class ApiUrls
    {
        public static string BaseUrl = WebConfigurationManager.AppSettings["BaseApiUrl"].ToString();
        public static string getAccessToken = BaseUrl + "/api/Auth/token";
        public static string GetUserMenu = BaseUrl + "/api/BackOffice/GetUserMenu";
    }
}