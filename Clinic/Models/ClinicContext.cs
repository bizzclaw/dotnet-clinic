﻿﻿﻿using System;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Models
{
    public class ClinicListContext : DbContext
    {
		public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=clinic;uid=root;pwd=root;");
    }
}
