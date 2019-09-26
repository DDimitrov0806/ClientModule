using ClientModule.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Services.Contracts
{
    public interface IClientService
    {
         void Create(ClientViewModel model, IFormFile image);

        List<ClientViewModel> GetClientList();

        ClientViewModel GetClient(Guid id);

        void Edit(ClientViewModel model);

        string Delete(Guid id);
    }
}
