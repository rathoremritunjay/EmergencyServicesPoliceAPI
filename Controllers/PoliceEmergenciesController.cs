using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmergencyServices.Models;

namespace EmergencyServices.Controllers
{
    public class PoliceEmergenciesController : ApiController
    {
        private EmergencyHelplineEntities db = new EmergencyHelplineEntities();

        // GET: api/PoliceEmergencies
        public IQueryable<PoliceEmergency> GetPoliceEmergencies()
        {
            return db.PoliceEmergencies;
        }

        // GET: api/PoliceEmergencies/5
        [ResponseType(typeof(PoliceEmergency))]
        public IHttpActionResult GetPoliceEmergency(int id)
        {
            PoliceEmergency policeEmergency = db.PoliceEmergencies.Find(id);
            if (policeEmergency == null)
            {
                return NotFound();
            }

            return Ok(policeEmergency);
        }

        // PUT: api/PoliceEmergencies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoliceEmergency(int id, PoliceEmergency policeEmergency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policeEmergency.id)
            {
                return BadRequest();
            }

            db.Entry(policeEmergency).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceEmergencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PoliceEmergencies
        [ResponseType(typeof(PoliceEmergency))]
        public IHttpActionResult PostPoliceEmergency(PoliceEmergency policeEmergency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoliceEmergencies.Add(policeEmergency);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = policeEmergency.id }, policeEmergency);
        }

        // DELETE: api/PoliceEmergencies/5
        [ResponseType(typeof(PoliceEmergency))]
        public IHttpActionResult DeletePoliceEmergency(int id)
         WE {
            PoliceEmergency policeEmergency = db.PoliceEmergencies.Find(id);
            if (policeEmergency == null)
            {
                return NotFound();
            }

            db.PoliceEmergencies.Remove(policeEmergency);
            db.SaveChanges();

            return Ok(policeEmergency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoliceEmergencyExists(int id)
        {
            return db.PoliceEmergencies.Count(e => e.id == id) > 0;
        }
    }
}