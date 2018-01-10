using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
	public class EFPatientRepository : IPatientRepository
	{
		ClinicListContext db = new ClinicListContext();

		public IQueryable<Patient> Patients
		{ get { return db.patients; } }

		public Patient Save(Patient patient)
		{
			db.patients.Add(patient);
			db.SaveChanges();
			return patient;
		}

		public Patient Edit(Patient patient)
		{
			db.Entry(patient).State = EntityState.Modified;
			db.SaveChanges();
			return patient;
		}

		public void Remove(Patient patient)
		{
			db.patients.Remove(patient);
			db.SaveChanges();
		}
	}
}