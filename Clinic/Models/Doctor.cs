﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    [Table("doctors")]
    public class Doctor
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

        public Doctor()
        {
            this.Patients = new HashSet<Patient>();
        }
    }
}
