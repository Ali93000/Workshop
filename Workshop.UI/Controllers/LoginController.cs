using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workshop.Entities.ApiModels.Category.Response;
using Workshop.UI.BLL;
using Workshop.UI.Models.Users;

namespace Workshop.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var languages = new List<Languages>
            {
                new Languages(){ Id = 1, LangName = "اللغة العربية"},
                new Languages(){ Id = 2, LangName = "English"}
            };
            ViewBag.Language = languages;
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin userLogin)
        {
            var languages = new List<Languages>
            {
                new Languages(){ Id = 1, LangName = "اللغة العربية"},
                new Languages(){ Id = 2, LangName = "English"}
            };
            ViewBag.Language = languages;

            // Call Api To Check User
            userLogin.CompCode = 1;
            userLogin.CompName = "Master Works";
            userLogin.RoleId = 1;
            userLogin.RoleName = "Manager"; 
            TempData["UserLoginData"] = userLogin;

            return RedirectToAction("UserBranch");
        }


        public ActionResult UserBranch()
        {
            var languages = new List<Languages>
            {
                new Languages(){ Id = 1, LangName = "الفرع الاول"},
                new Languages(){ Id = 2, LangName = "الفرع التانى"}
            };
            ViewBag.Language = languages;
            var data = TempData["UserLoginData"] as UserLogin;
            ViewBag.CompName = data.CompName;

            return View();
        }

        [HttpPost]
        public ActionResult UserBranch(UserLogin userLogin)
        {
            var languages = new List<Languages>
            {
                new Languages(){ Id = 1, LangName = "الفرع الاول"},
                new Languages(){ Id = 2, LangName = "الفرع التانى"}
            };
            ViewBag.Language = languages;

            var userInfo = TempData["UserLoginData"] as UserLoginInfo;
            userInfo.BraCode = userLogin.BraCode;
            Session["UserData"] = userInfo;
            // Call Api To Check User

            return RedirectToAction("Index", "Home");
        }
    }
}