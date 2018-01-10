using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
	public class EFPatientRepository : IPatientRepository
	{
		ToDoListContext db = new ToDoListContext();

		public IQueryable<Patient> patients
		{ get { return db.patients; } }

		public Patient Save(Patient patient)
		{
			db.Items.Add(patient);
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
			db.Items.Remove(patient);
			db.SaveChanges();
		}
	}
}