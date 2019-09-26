using ClientModule.Data;
using ClientModule.Models;
using ClientModule.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext dbContext;

        private UserManager<IdentityUser> userManager;

        public UserService(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            dbContext = context;
            this.userManager = userManager;
        }

        public List<UserViewModel> GetUserRoleList()
        {
            List<UserViewModel> uservm = dbContext.Users.Select(x => new UserViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                // RoleId=GetRoleId(x.Id),
                 RoleId = dbContext.UserRoles.Where(u => u.UserId == x.Id).Select(r => r.RoleId).FirstOrDefault(),
                 //RoleName= dbContext.Roles.Where(r => r.Id == roleId).Select(rn => rn.Name).FirstOrDefault(),
                Role = dbContext.Roles
                .Where(r => r.Id == dbContext.UserRoles.Where(u => u.UserId == x.Id).Select(ri => ri.RoleId).FirstOrDefault())
                .Select(rvm => new RoleViewModel
                {
                    Id = rvm.Id,
                    Name = rvm.Name
                }).FirstOrDefault()
            }).ToList();




            return uservm;
        }

        public UserViewModel GetUser(string id)
        {
            var roleId = dbContext.UserRoles.Where(us => us.UserId == id).Select(r => r.RoleId).FirstOrDefault();

            RoleViewModel roleViewModel = dbContext.Roles.Where(r => r.Id == roleId).Select(rvm => new RoleViewModel
            {
                Id = rvm.Id,
                Name = rvm.Name
            }).FirstOrDefault();

            UserViewModel model = dbContext.Users.Where(x => x.Id == id).Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Role = roleViewModel,
                /* RoleId=roleId,
                 RoleName=roleViewModel.Name*/


            }).FirstOrDefault();

            return model;
        }

        public async Task AssignToRole(UserViewModel uservm)
        {
            var user = dbContext.Users.Where(i => i.Id == uservm.Id).FirstOrDefault();

            var roles = await this.userManager.GetRolesAsync(user);
            await this.userManager.RemoveFromRolesAsync(user, roles.ToArray());


            IdentityResult identityResult;
            identityResult = await userManager.AddToRoleAsync(user, uservm.Role.Name);
        }

        public async Task Delete(string id)
        {
            var user = dbContext.Users.Where(i => i.Id == id).FirstOrDefault();

            var roles = await this.userManager.GetRolesAsync(user);
            await this.userManager.RemoveFromRolesAsync(user, roles.ToArray());

            await userManager.DeleteAsync(user);
        }
    }
}
