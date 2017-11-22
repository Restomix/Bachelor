using Bacheler_work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            if (newSensor != null)
            {
                db.sensors.Add(newSensor);
                db.SaveChanges();
            }
            return View("Main", db.sensors.ToList());
        }
        
        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetSensors()
        {
            return Json(db.sensors.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}