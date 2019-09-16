using ClientModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Services.Contracts
{
    public interface IClientService
    {
         void Create(ClientViewModel model);

        ClientViewModel Read(Guid id);

        void Update(ClientViewModel model);

        string Delete(Guid id);
    }
}
