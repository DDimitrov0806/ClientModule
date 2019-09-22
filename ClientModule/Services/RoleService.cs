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
    public class RoleService : IRoleService
    {
        private RoleManager<IdentityRole> roleManager;

        private ApplicationDbContext dbContext;

        public RoleService(RoleManager<IdentityRole> roleMgr, ApplicationDbContext context)
        {
            roleManager = roleMgr;

            dbContext = context;
        }

        public async Task Create(string role)
        {
            IdentityResult roleResult;

            roleResult = await roleManager.CreateAsync(new IdentityRole(role));
        }

        public List<RoleViewModel> GetRoleList()
        {
            return dbContext.Roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
        }

        public RoleViewModel GetRole(string id)
        {
            return dbContext.Roles.Where(r => r.Id == id).Select(rvm => new RoleViewModel
            {
                Id = rvm.Id,
                Name = rvm.Name
            }).FirstOrDefault();
        }

        public async Task Edit(RoleViewModel model)
        {
            //var role = dbContext.Roles.Where(r => r.Id == model.Id).FirstOrDefault();

            var role = await roleManager.FindByIdAsync(model.Id);

            role.Name = model.Name;
            role.NormalizedName = model.Name.ToUpper();

            await roleManager.UpdateAsync(role);
 
        }

        public async Task Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            await roleManager.DeleteAsync(role);
        }

    }

}
