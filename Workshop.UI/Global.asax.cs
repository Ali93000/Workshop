using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Workshop.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            //Server.ClearError();
            //string url = HttpContext.Current.Session["ErrorUrl"].ToString();
            ////url = url + "?err=" + ex.Message + "      " + ex.InnerException;
            //Response.Redirect(url);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //if (HttpContext.Current.Request.Cookies["systemProperties"] != null && HttpContext.Current.Request.Cookies["systemProperties"].Value != "null")
            //{
            //    string systemProperties = HttpContext.Current.Request.Cookies["systemProperties"].Value.ToString();

            //    var Lang = JsonConvert.DeserializeObject<SystemEnvironment>(systemProperties).ScreenLanguage;
            //    DateTimeFormatInfo usDtfi = new CultureInfo("en-GB", false).DateTimeFormat;
            //    usDtfi.ShortDatePattern = "dd/MM/yyyy";
            //    if (string.IsNullOrEmpty(Lang))
            //        Lang = "En";
            //string Lang = "ar-SA";
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Lang);
            ////System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat = usDtfi;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Lang);
            ////System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat = usDtfi;

            //}
        }
    }
}
