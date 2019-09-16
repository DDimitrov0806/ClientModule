
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Data
{
    public class Client
    {
        public Client()
        {
            VisitLog = new List<VisitLog>();
        }
        public System.Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int PostCode { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? LastVisit { get; set; }

        public string Explanation { get; set; }

        public ICollection<VisitLog> VisitLog {get;set;}

}
}
