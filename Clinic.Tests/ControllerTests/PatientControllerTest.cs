using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Clinic.Controllers;
using Clinic.Models;
using Moq;

namespace Clinic.Tests.ControllerTests
{
    public class PatientControllerTest
    {
        public PatientControllerTest()
        {
        }

		[TestMethod]
		public void PatientsController_IndexModelContainsCorrectData_List()
		{
			//Arrange
			Mock<IPatientRepository> mock = new Mock<IPatientRepository>();
			mock.Setup(m => m.Patients).Returns(new Patient[]
			{
				new Patient {Id = 1, Name = "John Paul Jones" },
				new Patient {Id = 2, Name = "Robert Plant" },
				new Patient {Id = 3, Name = "Jimmy Page" }
			}.AsQueryable());
            ViewResult indexView = new PatientsController(mock.Object).Index() as ViewResult;

			//Act
			var result = indexView.ViewData.Model;

			//Assert
			Assert.IsInstanceOfType(result, typeof(List<Patient>));
		}
    }
}
