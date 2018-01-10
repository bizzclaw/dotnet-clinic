using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public interface IPatientRepository
    {
        IQueryable<Patient> Patients { get; }
        Patient Save(Patient patient);
        Patient Edit(Patient patient);
        void Remove(Patient patient);
    }
}