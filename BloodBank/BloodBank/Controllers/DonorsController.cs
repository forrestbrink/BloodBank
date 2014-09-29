using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class DonorsController : Controller
    {
        //
        // GET: /Donors/
        Models.BloodBankEntities db = new Models.BloodBankEntities();
        public ActionResult Index()
        {
            return View(db.Donors);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Models.Donor());
        }

        [HttpPost]
        public ActionResult Create(Models.Donor donor)
        {
            db.Donors.Add(donor);
            db.SaveChanges();

            return RedirectToAction("Index2", "Donors");
        }

        public ActionResult Information(int id)
        {
            return View(db.Donors.Find(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Donors.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.Donor donor)
        {
            db.Entry(donor).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index2", "Donors");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Donors.Find(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            Models.Donor donorToDelete = db.Donors.Find(id);
            db.Donors.Remove(donorToDelete);
            db.SaveChanges();
            return RedirectToAction("Index2", "Donors");
        }
    }
}