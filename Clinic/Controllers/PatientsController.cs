﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic.Controllers
{
    public class PatientsController : Controller
    {
		private ClinicListContext db = new ClinicListContext();

		public IActionResult Index()
        {
            return View(db.patients.Include(PatientsController => PatientsController.Doctor).ToList());
        }

		public IActionResult Details(int id)
		{
			Patient model = db.patients.FirstOrDefault(patients => patients.Id == id);
			return View(model);
		}

		public IActionResult Create()
		{
            //bellow adds list of doctors - One must be selected per patient
            List<Doctor> model = db.doctors.ToList();
            //ViewBag.CategoryId = new SelectList(db.Doctors, "Id", "Name");
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(Patient patient)
		{
			db.patients.Add(patient);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var model = db.patients.FirstOrDefault(patients => patients.Id == id);
            ViewBag.CategoryId = new SelectList(db.doctors, "Id", "Name");
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(Patient patient)
		{
			db.Entry(patient).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var model = db.patients.FirstOrDefault(patients => patients.Id == id);
			return View(model);
		}

		[HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
		{
            var thisPatient = db.patients.FirstOrDefault(patients => patients.Id == id);
            db.patients.Remove(thisPatient);
            db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
