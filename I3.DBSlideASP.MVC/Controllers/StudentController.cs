using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using I3.DBSlideASP.MVC.Handlers;
using I3.DBSlideASP.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> service;

        public StudentController(IRepository<Student> service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<StudentListItem> students = service.Get().Select(s => s.ToListItem());
            //ViewBag.number = students.Count();
            //ViewData["number"] = students.Count();
            return View(students);
        }
        /// <summary>
        /// Action de suppression d'un étudiant à l'aide de son identifiant
        /// url d'accès : /student/delete/3
        /// </summary>
        /// <param name="id">Identifiant d'un student</param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            StudentNames student = service.Get(id).ToNames();
            if (!(student is null))
            {
                service.Delete(id);
                return View(student);
            }
            return View("DeleteFail",id);
            
            //Si pas de vue secondaire, on peut rediriger vers une action généraliste :
            //url :  /Home/Error/

            //return RedirectToAction("Error", "Home");
        }

        public IActionResult Details(int id)
        {
            StudentDetails student = service.Get(id).ToDetails();
            if(student is not null) return View(student);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            StudentCreateForm model = new StudentCreateForm();
            model.Section_ids = service.Get().Select(s => s.Section_ID).Distinct().OrderBy(s => s);
            ////SI votre propriétés est une List<int> alors on fini par ToList();
            //model.Section_ids = service.Get().Select(s => s.Section_ID).Distinct().ToList();
            ////SI votre propriétés est un int[] alors on fini par ToArray();
            //model.Section_ids = service.Get().Select(s => s.Section_ID).Distinct().ToArray();
            model.Course_ids = service.Get().Select(s => s.Course_ID).Distinct().OrderBy(c => c);
            model.DateNaissance = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(StudentCreateForm form)
        {
            ValidateYearsOld(form, ModelState, 18);
            if (!ModelState.IsValid)
            {
                form.Section_ids = service.Get().Select(s => s.Section_ID).Distinct().OrderBy(s => s);
                form.Course_ids = service.Get().Select(s => s.Course_ID).Distinct().OrderBy(c => c);
                return View(form);
            }
            service.Insert(form.ToDTO());
            return RedirectToAction("Index");
        }

        private static void ValidateYearsOld(StudentCreateForm form, ModelStateDictionary modelState, int yearsOld ) {

            int currentYear = DateTime.Now.Year;
            int age = currentYear - form.DateNaissance.Year;
            if (age < yearsOld) modelState.AddModelError(nameof(form.DateNaissance), $"Vous n'avez pas encore {yearsOld} ans...");
        }
    }
}
