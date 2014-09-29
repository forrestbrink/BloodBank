using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class PatientsController : Controller
    {
        //
        // GET: /Patient/
        BloodBank.Models.BloodBankEntities db = new Models.BloodBankEntities();
        public ActionResult Index()
        {
            return View(db.Patients);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Models.Patient());
        }

        [HttpPost]
        public ActionResult Create(Models.Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();

            return RedirectToAction("Index", "Patient");
        }

        public ActionResult Information(int id)
        {
            return View(db.Patients.Find(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Patients.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.Patient patient)
        {
            db.Entry(patient).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Patient");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Patients.Find(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            Models.Patient patientToDelete = db.Patients.Find(id);
            db.Patients.Remove(patientToDelete);
            db.SaveChanges();
            return RedirectToAction("Index", "Patient");
        }
    }
}