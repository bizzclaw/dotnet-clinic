using System;
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
    public class DoctorsController : Controller
    {
        private ClinicListContext db = new ClinicListContext();

        // GET: /<controller>/
        //lists doctors
        public IActionResult Index()
        {
            List<Doctor> model = db.doctors.ToList() as List<Doctor>;    
            return View(model);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
