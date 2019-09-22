using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientModule.Models;
using ClientModule.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClientModule.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        private IRoleService roleService;

        public UserController(IUserService userService,IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;

        }

        public IActionResult Users()
        {
            return View(userService.GetUserRoleList());
        }

        public IActionResult Edit(string id)
        {
            /*var roleList = roleService.GetRoleList();

            ViewBag.RoleId = new SelectList(roleList, "Id", "RoleName", userService.GetUser(id).Role.Id);*/

            return View(userService.GetUser(id));
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {

            
            //if (ModelState.IsValid)
            //{ 


            //    userService.AssignToRole(user).Wait();


            //    return RedirectToAction("Users");
            //}

            if (ModelState.IsValid)
            {
                userService.AssignToRole(user).Wait();


                return RedirectToAction("Users");
            }

            var roleList = roleService.GetRoleList();

            ViewBag.Roles = new SelectList(roleList, "Id", "RoleName",user.Role.Id);

            /*var fromDatabaseEF = new SelectList(roleList, "Id", "Name");
            ViewData["RoleList"] = fromDatabaseEF;*/

            /*this.ViewData["RoleList"] = roleService
                    .GetRoleList()
                    .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id })
                    .ToList();*/

            return View(user);
        }

        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                userService.Delete(id).Wait();

                return RedirectToAction("Users");
            }
            return View();
        }
    }
}