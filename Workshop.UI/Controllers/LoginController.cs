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
            UserConsumer userConsumer = new UserConsumer();
            UserLoginInfoResponse result = userConsumer.Login(userLogin);
            if (result.IsSuccessful == false && result.ResponseCode != System.Net.HttpStatusCode.OK)
            {
                ModelState.AddModelError("loginFailed", Resources.SysResource.LoginFailed);
                return View();
            }
            TempData["UserLoginData"] = result;
            TempData.Keep();
            return RedirectToAction("UserBranch");
        }


        public ActionResult UserBranch()
        {
            BranchConsumer branchConsumer = new BranchConsumer();
            Models.Branch.BranchesResponse branches = branchConsumer.GetAllBranches();
            
            ViewBag.BranchesList = branches.BranchesList;
            var userData = TempData["UserLoginData"] as UserLoginInfoResponse;
            TempData.Keep();
            ViewBag.CompName = userData.UserLoginInfo.CompName;

            return View();
        }

        [HttpPost]
        public ActionResult UserBranch(UserLogin userLogin)
        {
            BranchConsumer branchConsumer = new BranchConsumer();
            Models.Branch.BranchesResponse branches = branchConsumer.GetAllBranches();

            ViewBag.BranchesList = branches.BranchesList;
            var userInfo = TempData["UserLoginData"] as UserLoginInfoResponse;
            TempData.Keep();
            userInfo.UserLoginInfo.BraCode = userLogin.BraCode;
            Session["UserData"] = userInfo.UserLoginInfo;
            // Call Api To Get Token
            var accessToken = TokenConsumer.GetAccessToken(userInfo);
            Session["token"] = accessToken;
            return RedirectToAction("Index", "Home");
        }
    }
}