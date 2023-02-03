using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;
using MVC.Models.ITLangViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class ITLangController : Controller
    {
        private readonly IITLangRepository<ITLang, int> _service;
        public ITLangController(IITLangRepository<ITLang, int> service)
        {
            _service = service;
        }

        // GET: ITLangController
        public ActionResult Index()
        {
            IEnumerable<ITLangListItem> model = _service.Get().Select(e => e.ToListItem());
            return View(model);
        }

        // GET: ITLangController/Details/5
        public ActionResult Details(int id)
        {
            ITLangDetails model = _service.Get(id).ToDetails();
            return View(model);
        }

        // GET: ITLangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ITLangController/Create
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

        // GET: ITLangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ITLangController/Edit/5
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

        // GET: ITLangController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ITLangController/Delete/5
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
