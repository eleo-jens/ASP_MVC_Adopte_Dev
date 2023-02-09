using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;
using MVC.Models.AuthViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly SessionManager _sessionManager; 
        private readonly IClientRepository<Client, int> _clientService;
        public AuthController(IClientRepository<Client, int> clientService, SessionManager sessionManager)
        {
            _clientService = clientService;
            _sessionManager = sessionManager;
        }

        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid) return View();
            int? id = _clientService.CheckPassword(form.login, form.password);
            if (id is null)
            {
                ViewBag.ErrorMsg = "Les identifiants ne sont pas corrects ou l'utilisateur n'existe pas";
                return View();
            }
            CurrentUser currentUser = new CurrentUser()
            {
                idUser = (int)id,
                login = form.login,
                lastConnexion = DateTime.Now
            };
            _sessionManager.CurrentUser = currentUser;
            return RedirectToAction("Index", "Home"); 

        }

        public IActionResult Logout()
        {
            _sessionManager.CurrentUser = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
