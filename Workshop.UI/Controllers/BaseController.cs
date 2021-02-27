using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Workshop.Entities.DTO.User;

namespace Workshop.UI.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() { }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public Workshop.Entities.DTO.User.UserDTO _CurrentLoginModel
        {
            get
            {
                //Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddYears(-30);
                //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                try
                {
                    return System.Web.HttpContext.Current.Session["CurrentLoginModel"] == null ? null : System.Web.HttpContext.Current.Session["CurrentLoginModel"] as UserDTO;
                }
                catch { }
                return null;
            }
            set
            {
                System.Web.HttpContext.Current.Session["CurrentLoginModel"] = value;
            }

        }

        //public bool IsValidLogin()
        //{
        //    try
        //    {
        //        if (_CurrentLoginModel != null && _CurrentLoginModel.IsValid == true)
        //            return true;
        //    }
        //    catch { }
        //    return false;
        //}



        public void ClearSession()
        {
            Session.Abandon();
            // in case a attacker has forced a cookie with a future expiration date, expire that cookie as well

            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddYears(-30);
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }

    }
}