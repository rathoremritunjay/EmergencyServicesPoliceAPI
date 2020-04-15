using EmergencyServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult alert()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //FeedPass
        public ActionResult FeedPass(Contact data)
        {
            String Qry = "insert into ContactDetails(Name,Email,Contact,Msg) values ('" + data.feedName+"','"+data.feedEmail+"','"+data.feedContact+"','"+data.feedMsg+"')";
            data.Query(Qry);
            return View("alert");
        }

        }
}