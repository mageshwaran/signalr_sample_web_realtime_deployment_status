using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdRelease.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTeamsReleaseStatus()
        {
            /* this is static variable. If application shutdown the data won't be there
             * for demo this is enough i think
             * If you want save the status in DB and retrieve here.
             */
            var releaseStatus = ReleaseStatusHub.TeamMembers 
                .Select(y => new Dictionary<string, string>
                {
                    { $"{y.Key}", y.Value }
                }).ToList();
            return Json(releaseStatus, JsonRequestBehavior.AllowGet);
        }
    }
}