using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientModule.Models;
using ClientModule.Services;
using ClientModule.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ClientModule.Controllers
{
    public class ClientController : Controller
    {
        private IClientService clientService;

        public ClientController(IClientService service)
        {
            clientService = service;
        }
        
        public IActionResult Create()
        {
            ClientViewModel model = new ClientViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create (ClientViewModel model)
        {
            clientService.Create(model);
            return RedirectToAction("Index", "Home");
        }
    }
}