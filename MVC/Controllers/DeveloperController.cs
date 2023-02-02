using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;
using MVC.Models.DeveloperViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperRepository<Developer, int> _service;
        public DeveloperController(IDeveloperRepository<Developer,int> service)
        {
            _service = service;
        }
        // GET: DeveloperControllers
        public ActionResult Index()
        {
            IEnumerable<DeveloperListItem> model = _service.Get().Select(e => e.ToListItem());
            return View(model);
        }

        // GET: DeveloperController/Details/5
        public ActionResult Details(int id)
        {
            DeveloperDetails model = _service.Get(id).ToDetails();
            if (model is null)
            {
                TempData["Error"] = "Spectacle inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: DeveloperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeveloperController/Create
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
        }

        // GET: DeveloperController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeveloperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeveloperController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeveloperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
