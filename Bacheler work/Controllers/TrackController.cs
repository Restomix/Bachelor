using Bacheler_work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bacheler_work.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewData["Datas"] = db.Data.ToList();
            return View("Main", db.sensors.ToList());
        }
        [HttpPost]
        public ActionResult AddSensor(Sensor newSensor)
        {
            ViewData["Datas"] = db.Data.ToList();
            db.sensors.Add(newSensor);
            db.SaveChanges();
            return View("Main", db.sensors.ToList());
        }
    }
}