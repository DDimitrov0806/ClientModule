using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientModule.Models;
using ClientModule.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClientModule.Controllers
{
    public class RoleController : Controller
    {

        private IRoleService roleService;

        public RoleController(IRoleService service)
        {
            roleService = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string role)
        {
            roleService.Create(role).Wait();



            return RedirectToAction("Index", "Home");
        }

        public IActionResult Roles()
        {
            return View(roleService.GetRoleList());
        }

        public IActionResult Edit(string id)
        {
            return View(roleService.GetRole(id));
        }

        [HttpPost]
        public IActionResult Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                roleService.Edit(model).Wait();


                return RedirectToAction("Roles");
            }

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            if(ModelState.IsValid)
            {
                roleService.Delete(id).Wait();

                return RedirectToAction("Roles");
            }

            return View();
        }
    }
}