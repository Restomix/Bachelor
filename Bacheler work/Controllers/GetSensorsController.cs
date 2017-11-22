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
using Bacheler_work.Models;

namespace Bacheler_work.Controllers
{
    public class GetSensorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GetSensors
        public IQueryable<Sensor> Getsensors()
        {
            return db.sensors;
        }

        // GET: api/GetSensors/5
        [ResponseType(typeof(Sensor))]
        public IHttpActionResult GetSensor(int id)
        {
            Sensor sensor = db.sensors.Find(id);
            if (sensor == null)
            {
                return NotFound();
            }

            return Ok(sensor);
        }

        // PUT: api/GetSensors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSensor(int id, Sensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sensor.Id)
            {
                return BadRequest();
            }

            db.Entry(sensor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id))
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

        // POST: api/GetSensors
        [ResponseType(typeof(Sensor))]
        public IHttpActionResult PostSensor(Sensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sensors.Add(sensor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sensor.Id }, sensor);
        }

        // DELETE: api/GetSensors/5
        [ResponseType(typeof(Sensor))]
        public IHttpActionResult DeleteSensor(int id)
        {
            Sensor sensor = db.sensors.Find(id);
            if (sensor == null)
            {
                return NotFound();
            }

            db.sensors.Remove(sensor);
            db.SaveChanges();

            return Ok(sensor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SensorExists(int id)
        {
            return db.sensors.Count(e => e.Id == id) > 0;
        }
    }
}