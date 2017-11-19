using DDACUIA.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDACUIA.Controllers
{
    public class FlightController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        // GET: Flight
        public ActionResult SearchFlight()
        {
            return View(new List<Flight>());
        }
        [HttpPost]
        public ActionResult SearchFlight(String searcho, String searchd, String ddate)
        {
            DateTime departuredate = DateTime.ParseExact(ddate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var Flightsearch = db.Flight.Include("Origin").Include("Destination").Where(x => x.Origin.City.Contains(searcho) && x.Destination.City.Contains(searchd) && DbFunctions.DiffDays(x.DepartureDate, departuredate) == 0 || searcho == null).ToList();

            return View(Flightsearch);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Book(int? id)
        {
            Flight BookFlight = db.Flight.Include("Origin").Include("Destination").Where(x=> x.FlightId == (id)).First();

            return View(BookFlight);   
            
        }

        [Authorize]
        public ActionResult BookingConfirmation(int id)
        {
            //get current user from database 
            string userId = User.Identity.GetUserId();
            Flight FlightId = db.Flight.Find(id);

            Booking booking = new Booking();
            booking.FlightId = FlightId;

            db.Users.Find(userId).BookingId.Add(booking);
            db.SaveChanges();
            return View();
        }

    }
}