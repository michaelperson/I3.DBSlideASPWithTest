using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using I3.DBSlideASP.MVC.Controllers;
using I3.DBSlideASP.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3.DBSlideAsp.Test
{
    public class ProfessorControllerTest
    {
        [Test]
        public void DetailsTest()
        {
            //Arrange
            //Créer un Fake pour avoir un repo de professor
            IRepository<Professor> PRepo = new Fake.FakeProfessorRepository();                
            ProfessorController pctl = new ProfessorController(PRepo);
            //Act
           IActionResult result = pctl.Details(1);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOf<ProfessorDetails>((result as ViewResult).Model);
            ProfessorDetails prof = ((result as ViewResult).Model) as ProfessorDetails;
            Assert.AreEqual(1,prof.Professor_Id);

        }

        [Test]
        public void DetailsExceptionTest()
        {
            //Arrange
            //Créer un Fake pour avoir un repo de professor
            IRepository<Professor> PRepo = new Fake.FakeProfessorRepository();
            ProfessorController pctl = new ProfessorController(PRepo);
            //Act & Assert
            //Ceci n'est pas valable si vous capturer l'exception dans le controller
            //Assert.Throws<ArgumentOutOfRangeException>(()=>pctl.Details(2));
            IActionResult result = pctl.Details(2);

            //Assert
            //return RedirectToAction(nameof(Index));
            Assert.IsInstanceOf<RedirectToActionResult>(result);

            //TempData["Error"] = e.Message;
            //ToDo: test


        }
    }
}
