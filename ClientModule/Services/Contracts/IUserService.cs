using ClientModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Services.Contracts
{
    public interface IUserService
    {
        List<UserViewModel> GetUserRoleList();

        UserViewModel GetUser(string id);

        Task AssignToRole(UserViewModel uservm);

        Task Delete(string id);
    }
}
