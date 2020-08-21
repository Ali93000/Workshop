using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workshop.Entities.DTO.User;
using Workshop.UI.BLL;

namespace Workshop.UI.Controllers
{
    public class HomeController : BaseController
    {
        int? compCode;
        int? braCode;
        public HomeController()
        {
            compCode = _CurrentLoginModel.CompCode;
            braCode = _CurrentLoginModel.BraCode;
        }
        public ActionResult Index() 
        {
            BranchConsumer branchConsumer = new BranchConsumer();
            Models.Branch.BranchesResponse branches = branchConsumer.GetAllBranches();
            return View(branches.BranchesList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}