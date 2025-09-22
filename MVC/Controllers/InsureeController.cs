using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            // Check if the submitted form meets the model’s validation rules
            if (!ModelState.IsValid)
            {
                // If validation fails, return to the form view with current data and error messages
                return View(insuree);
            }

            // Start with the base rate for all applicants
            decimal baseQuote = 50.00m;

            // Determine age by comparing birth year with current year
            int age = DateTime.Today.Year - insuree.DateOfBirth.Year;
            if (insuree.DateOfBirth > DateTime.Today.AddYears(-age)) age--;

            // Add age-related surcharge to the quote
            if (age <= 18)
            {
                baseQuote += 100m;
            }
            else if (age <= 25)
            {
                baseQuote += 50m;
            }
            else
            {
                baseQuote += 25m;
            }

            // Apply car age adjustment: older than 2000 or newer than 2015 = higher risk
            if (insuree.CarYear < 2000 || insuree.CarYear > 2015)
            {
                baseQuote += 25m;
            }

            // Normalize car make and model for comparison (case-insensitive)
            string make = insuree.CarMake?.Trim().ToLower() ?? "";
            string model = insuree.CarModel?.Trim().ToLower() ?? "";

            // Additional charge for specific high-risk or high-performance vehicles
            if (make == "Toyota")
            {
                baseQuote += 25m;

                if (model == "Camero")
                {
                    baseQuote += 25m;
                }
            }

            // Add $10 for each speeding ticket on record
            baseQuote += insuree.SpeedingTickets * 10m;

            // Apply DUI penalty: increase total quote by 25%
            if (insuree.DUI)
            {
                baseQuote *= 1.25m;
            }

            // Apply 50% surcharge if full coverage is selected
            if (insuree.CoverageType)
            {
                baseQuote *= 1.50m;
            }

            // Save the calculated quote to the insuree object
            insuree.Quote = baseQuote;

            // Add the insuree record to the database and save changes
            db.Insurees.Add(insuree);
            db.SaveChanges();

            // Redirect to the Index page after saving successfully
            return RedirectToAction("Index");
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
