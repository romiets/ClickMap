using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Script.Serialization;
using ClickMap.Helper;
using ClickMap.Helper.External.Models;

namespace ClickMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetEvent(int Id)
        {
            XMLReader xmlReader = new XMLReader();
            var data = xmlReader.ReturnListOfEvents();
            var result = from e in data
                         where e.Id == Id
                         select e;
            var json = new JavaScriptSerializer().Serialize(result);
            return Json(new { success = true, message = json, }, JsonRequestBehavior.AllowGet);
        }

    }
}