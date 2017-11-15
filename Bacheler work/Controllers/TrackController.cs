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
        public ActionResult Index()
        {
            return View("Main");
        }
        [HttpPost]
        public ActionResult AddSensor(Sensor one)
        {
            return View(one);
        }
    }
}