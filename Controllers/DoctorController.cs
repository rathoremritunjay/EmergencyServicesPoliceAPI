using EmergencyServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyServices.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        EmergencyHelplineEntities obj = new EmergencyHelplineEntities();

        public ActionResult DoctorList()
        {
            return View(obj.MedicalEmergencies.ToList());
        }

        public ActionResult List()
        {
            return View(obj.MedicalEmergencies.ToList());
        }


        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] MedicalEmergency data)
        {

            if (!ModelState.IsValid)
                return View();
            obj.MedicalEmergencies.Add(data);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("DoctorList");


        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.MedicalEmergencies where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(MedicalEmergency IdToEdit)
        {
            var orignalRecord = (from m in obj.MedicalEmergencies where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj.SaveChanges();
            return RedirectToAction("DoctorList");

        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(MedicalEmergency IdToDel)
        {
            var d = obj.MedicalEmergencies.Where(x => x.id == IdToDel.id).FirstOrDefault();
            obj.MedicalEmergencies.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("DoctorList");

        }

        // POST: Doctor/Delete/5
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
