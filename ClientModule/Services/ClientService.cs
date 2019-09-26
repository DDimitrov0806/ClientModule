using ClientModule.Data;
using ClientModule.Models;
using ClientModule.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Services
{
    public class ClientService : IClientService
    {
        private ApplicationDbContext dbContext;

        public ClientService(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public  void Create(ClientViewModel model,IFormFile image)
        {

            using (var target = new MemoryStream())
            {
                image.CopyTo(target);

                dbContext.Clients.Add(new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    PostCode = model.PostCode,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    LastVisit = DateTime.UtcNow,
                    Explanation = model.Explanation,
                    Image = target.ToArray(),
                    ContentType = image.ContentType

                });
                dbContext.SaveChanges();
            }
            
        }

        public List<ClientViewModel> GetClientList()
        {
            return dbContext.Clients.Select(m => new ClientViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                MiddleName = m.MiddleName,
                LastName = m.LastName,
                Address = m.Address,
                City = m.City,
                Country = m.Country,
                PostCode = m.PostCode,
                PhoneNumber = m.PhoneNumber,
                Email = m.Email,
                LastVisit = m.LastVisit,
                Explanation = m.Explanation,
                ViewImage = m.Image,
                ContentType = m.ContentType


            }).ToList();
        }

        public ClientViewModel GetClient(Guid id)
        {
            ClientViewModel model = dbContext.Clients.Where(c => c.Id == id).Select(m => new ClientViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                MiddleName = m.MiddleName,
                LastName = m.LastName,
                Address = m.Address,
                City = m.City,
                Country = m.Country,
                PostCode = m.PostCode,
                PhoneNumber = m.PhoneNumber,
                Email = m.Email,
                LastVisit = m.LastVisit,
                Explanation = m.Explanation,
                ViewImage=m.Image,
                ContentType=m.ContentType


            }).FirstOrDefault();

            

            return model;
        }

        public void Edit(ClientViewModel model)
        {
            

            Client client = new Client
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                PostCode = model.PostCode,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                LastVisit = DateTime.UtcNow,
                Explanation = model.Explanation


            };

            dbContext.Entry(client).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public string Delete(Guid id)
        {
            Client client = dbContext.Clients.Where(c => c.Id == id).FirstOrDefault();

            if(client==null)
            {
                return "Client can't be deleted";
            }

            dbContext.Clients.Remove(dbContext.Clients.Where(c => c.Id == id).FirstOrDefault());

            dbContext.SaveChanges();

            return null;
        }
    }
}
