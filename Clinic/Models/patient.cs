﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    [Table("patients")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BloodType { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public bool NeedsCare { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
