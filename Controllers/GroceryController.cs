using EmergencyServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyServices.Controllers
{
    public class GroceryController : Controller
    {
        // GET: Grocery
        EmergencyHelplineEntities obj = new EmergencyHelplineEntities();

        public ActionResult GroceryList()
        {
            return View(obj.GroceryEmergencies.ToList());
        }

        public ActionResult List()
        {
            return View(obj.GroceryEmergencies.ToList());
        }

        // GET: Grocery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Grocery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grocery/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]GroceryEmergency data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.GroceryEmergencies.Add(data);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("GroceryList");
        }

        // GET: Grocery/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.GroceryEmergencies where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Grocery/Edit/5
        [HttpPost]
        public ActionResult Edit(GroceryEmergency IdToEdit)
        {
            var orignalRecord = (from m in obj.GroceryEmergencies where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj.SaveChanges();
            return RedirectToAction("GroceryList");

        }

        // GET: Grocery/Delete/5
        public ActionResult Delete(GroceryEmergency IdToDel)
        {
            var d = obj.GroceryEmergencies.Where(x => x.id == IdToDel.id).FirstOrDefault();
            obj.GroceryEmergencies.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("GroceryList");
        }

        // POST: Grocery/Delete/5
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
