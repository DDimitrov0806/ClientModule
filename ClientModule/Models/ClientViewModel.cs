using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Models
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int PostCode { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime? LastVisit { get; set; }

        public string Explanation { get; set; }
    }
}
