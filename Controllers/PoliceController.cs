using EmergencyServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyServices.Controllers
{
    public class PoliceController : Controller
    {
        // GET: Police
        EmergencyHelplineEntities obj = new EmergencyHelplineEntities();

        public ActionResult PoliceList()
        {
            return View(obj.PoliceEmergencies.ToList());
        }

        public ActionResult List()
        {
            return View(obj.PoliceEmergencies.ToList());
        }

        // GET: Police/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Police/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Police/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] PoliceEmergency data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.PoliceEmergencies.Add(data);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("PoliceList");
        }

        // GET: Police/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.PoliceEmergencies where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Police/Edit/5
        [HttpPost]
        public ActionResult Edit(PoliceEmergency IdToEdit)
        {
            var orignalRecord = (from m in obj.PoliceEmergencies where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj.SaveChanges();
            return RedirectToAction("PoliceList");

        }

        // GET: Police/Delete/5
        public ActionResult Delete(PoliceEmergency IdToDel)
        {
            var d = obj.PoliceEmergencies.Where(x => x.id == IdToDel.id).FirstOrDefault();
            obj.PoliceEmergencies.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("PoliceList");
        }

        // POST: Police/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
