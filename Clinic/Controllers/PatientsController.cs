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
		private IPatientRepository patientRepo;

		public PatientsController(IPatientRepository repo = null)
		{
			if (repo == null)
			{
				this.patientRepo = new EFPatientRepository();
			}
			else
			{
				this.patientRepo = repo;
			}
		}


		public ViewResult Index()
        {
			return View(patientRepo.Patients.ToList());
		}

		public IActionResult Details(int id)
		{
			Patient thisPatient = patientRepo.Patients.FirstOrDefault(x => x.Id == id);
			return View(thisPatient);
		}

		public IActionResult Create()
		{
            return View();
		}

		[HttpPost]
		public IActionResult Create(Patient patient)
		{
			patientRepo.Save(patient);   // Updated
								   // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			Patient thisPatient = patientRepo.Patients.FirstOrDefault(x => x.Id == id);
			return View(thisPatient);

		}

		[HttpPost]
		public IActionResult Edit(Patient patient)
		{
			patientRepo.Edit(patient);   // Updated!
								   // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			Patient thisPatient = patientRepo.Patients.FirstOrDefault(x => x.Id == id);
			return View(thisPatient);
		}

		[HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
		{
			// Updated:
			Patient thisPatient = patientRepo.Patients.FirstOrDefault(x => x.Id == id);
			patientRepo.Remove(thisPatient);   // Updated!
										 // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}
	}
}
