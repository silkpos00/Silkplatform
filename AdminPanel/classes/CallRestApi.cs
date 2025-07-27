using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace AdminPanel.classes
{
    public class CallRestApi
    {
        public static dynamic SendRequest2(dynamic param, string url, string method = "POST")
        {
            try
            {
                var req = WebRequest.Create(url);
                req.Method = method.ToUpper();
                req.Headers.Add("Content", "application/json");
                req.ContentType = "application/json";

                if (param != null)
                {
                    using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(param);
                        streamWriter.Write(json);
                    }
                }

                using (var response = (HttpWebResponse)req.GetResponse())
                {
                    var statusCode = response.StatusCode;

                    using (var stream = response.GetResponseStream())
                    using (var sr = new StreamReader(stream))
                    {
                        string json = sr.ReadToEnd();

                        // وضعیت کد را به همراه پاسخ برگردان
                        return new
                        {
                            StatusCode = (int)statusCode,
                            Data = JsonConvert.DeserializeObject<dynamic>(json)
                        };
                    }
                }
            }
            catch (WebException ex) when (ex.Response is HttpWebResponse errorResponse)
            {
                var statusCode = errorResponse.StatusCode;

                using (var stream = errorResponse.GetResponseStream())
                using (var sr = new StreamReader(stream))
                {
                    string errorJson = sr.ReadToEnd();

                    return new
                    {
                        StatusCode = (int)statusCode,
                        Error = JsonConvert.DeserializeObject<dynamic>(errorJson)
                    };
                }
            }
            catch (Exception ex)
            {
                // خطای غیرشبکه‌ای
                return new
                {
                    StatusCode = 0,
                    Error = ex.Message
                };
            }
        }
        public static dynamic SendRequest(dynamic param, string url, string method = "POST", string token = null)
        {
            try
            {
                var req = WebRequest.Create(url);
                req.Method = method.ToUpper();

                // هدر Content-Type
                req.ContentType = "application/json";

                // افزودن توکن اگر موجود بود
                if (!string.IsNullOrEmpty(token))
                {
                    req.Headers.Add("Authorization", "Bearer " + token);
                }

                if (param != null)
                {
                    using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(param);
                        streamWriter.Write(json);
                    }
                }

                using (var response = (HttpWebResponse)req.GetResponse())
                {
                    var statusCode = response.StatusCode;

                    using (var stream = response.GetResponseStream())
                    using (var sr = new StreamReader(stream))
                    {
                        string json = sr.ReadToEnd();

                        return new
                        {
                            StatusCode = (int)statusCode,
                            Data = JsonConvert.DeserializeObject<dynamic>(json)
                        };
                    }
                }
            }
            catch (WebException ex) when (ex.Response is HttpWebResponse errorResponse)
            {
                var statusCode = errorResponse.StatusCode;

                using (var stream = errorResponse.GetResponseStream())
                using (var sr = new StreamReader(stream))
                {
                    string errorJson = sr.ReadToEnd();

                    return new
                    {
                        StatusCode = (int)statusCode,
                        Error = JsonConvert.DeserializeObject<dynamic>(errorJson)
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    StatusCode = 0,
                    Error = ex.Message
                };
            }
        }


    }
}