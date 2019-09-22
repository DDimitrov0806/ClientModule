using ClientModule.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Services.Contracts
{
   public interface IRoleService
    {
         Task Create(string role );
        //RoleManager<IdentityRole> roleManager { get; set; }
        List<RoleViewModel> GetRoleList();

        RoleViewModel GetRole(string id);

        Task Edit(RoleViewModel model);

        Task Delete(string id);
    }
}
