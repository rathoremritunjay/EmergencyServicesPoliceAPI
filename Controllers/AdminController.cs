using EmergencyServices.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyServices.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Work()
        {
            return View();
        }

        public ActionResult NotWork()
        {
            return View();
        }


        //loginPass
        public ActionResult loginPass(AdminLogin log) {

            String query = "select * from AdminDetails where UserName='"+log.UserName+"' and UserPassword='"+log.UserPassword+"'";
            DataTable tbl = new DataTable();
            tbl = log.srchRecord(query);

            if (tbl.Rows.Count > 0)
            {
                return View("Work");
            }
            else {
                return View("NotWork");
            }
        }

    }
}