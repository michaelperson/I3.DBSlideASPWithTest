using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using I3.DBSlideASP.MVC.Handlers;
using I3.DBSlideASP.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IRepository<Professor> _service;

        public ProfessorController(IRepository<Professor> service)
        {
            this._service = service;
        }

        // GET: Professor?primarySort=section
        // GET: Professor/Index?primarySort=section
        public ActionResult Index(string primarySort)
        {
            if (TempData.ContainsKey("Error")) TempData.Keep();
            IEnumerable<ProfessorListItem> model = this._service.Get()
                                                    .Select(p => p.ToListItem());
            if (primarySort is null)
            {
                model = model.OrderBy(m => m.Professor_Name);
                return View(model);
            }
            switch (primarySort.ToLower())
            {
                case "nom" :
                    model = model.OrderBy(m => m.Professor_Name);
                    break;
                case "prenom":
                    model = model.OrderBy(m => m.Professor_Surname);
                    break;
                case "section":
                    model = model.OrderBy(m => m.Section_Id);
                    break;
                default:
                    break;
            }
            return View(model);
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ProfessorDetails model = this._service.Get(id).ToDetails();
                if (model is null) throw new ArgumentOutOfRangeException(nameof(id),"Identifiant non compris dans la liste.");
                return View(model);
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }

        }

        
        /*// GET: ProfessorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: ProfessorController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ProfessorEditForm model = this._service.Get(id).ToEditForm();
                if (model is null) throw new ArgumentOutOfRangeException(nameof(id), "Identifiant non compris dans la liste.");
                return View(model);
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));                
            }
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProfessorEditForm collection)
        {
            try
            {
                ProfessorDetails result = this._service.Get(id).ToDetails();
                if (result is null) throw new ArgumentOutOfRangeException(nameof(id), "Identifiant non compris dans la liste.");
                if (!ModelState.IsValid) throw new ArgumentException("Formulaire erroné");
                result.Professor_Office = collection.Professor_Office;
                result.Professor_Wage = collection.Professor_Wage;
                this._service.Update(id, result.ToDTO());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ProfessorController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ProfessorDeleteForm model = this._service.Get(id).ToDeleteForm();
                if (model is null) throw new ArgumentOutOfRangeException(nameof(id), "Identifiant non compris dans la liste.");
                return View(model);
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ProfessorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProfessorDeleteForm collection)
        {
            try
            {
                ProfessorDeleteForm model = this._service.Get(id).ToDeleteForm();
                if (model is null) throw new ArgumentOutOfRangeException(nameof(id), "Identifiant non compris dans la liste.");
                this._service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
