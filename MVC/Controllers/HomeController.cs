using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Handlers;
using MVC.Models;
using MVC.Models.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeveloperRepository<Developer, int> _devService;
        private readonly ICategoriesRepository<Categories, int> _catService;
        private readonly IITLangRepository<ITLang, int> _itlangService; 

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDeveloperRepository<Developer, int> devService, ICategoriesRepository<Categories, int> catService, IITLangRepository<ITLang, int> itlangService)
        {
            _logger = logger;
            _devService = devService;
            _catService = catService;
            _itlangService = itlangService;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.developers = _devService.Get().Select(e => e.ToListItem());
            model.categories = _catService.Get();
            model.langues = _itlangService.Get().Select(e => e.ToListItem()); 
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
