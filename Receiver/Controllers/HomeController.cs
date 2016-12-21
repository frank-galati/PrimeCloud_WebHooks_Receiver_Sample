using Receiver.WebHooks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Receiver.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Microsoft ASP.NET WebHooks Custom Receiver";

            return View();
        }

        public ActionResult GetData()
        {
            ViewBag.Data = CustomWebHookHandler.notifications.ToList();

            return PartialView();
        }
    }
}
