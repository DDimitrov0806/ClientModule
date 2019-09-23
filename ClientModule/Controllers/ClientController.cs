using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClientModule.Models;
using ClientModule.Services;
using ClientModule.Services.Contracts;
using Microsoft.AspNetCore.Http;
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
            /*IFormFile uploadedImage = model.Image;

            MemoryStream ms = new MemoryStream();

            uploadedImage.OpenReadStream().CopyTo(ms);

            model.ViewImage = ms.ToArray();
            model.ContentType = uploadedImage.ContentType;*/


           
             clientService.Create(model);
             return RedirectToAction("Index", "Home");
           
        }

        public IActionResult Display(Guid id)
        {
            var model = clientService.GetClient(id);

            return View(model);
        }

        public IActionResult Clients()
        {
            return View(clientService.GetClientList());
        }

        public IActionResult Edit(Guid id)
        {
            return View(clientService.GetClient(id));
        }

        [HttpPost]
        public IActionResult Edit(ClientViewModel model)
        {
            if(ModelState.IsValid)
            {
                 clientService.Edit(model);
                return RedirectToAction("Clients");
            }

            return View(model);

        }

        public IActionResult Delete(Guid id)
        {
            clientService.Delete(id);

            return RedirectToAction("Clients");
        }
    }
}