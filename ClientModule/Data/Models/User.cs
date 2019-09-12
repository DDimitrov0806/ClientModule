using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Data
{
    public class User : IdentityUser
    {
        public User()
        {
            ActivityLogs = new HashSet<ActivityLog>();
        }

        public System.Guid Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int PostCode { get; set; }

        public int PhoneNumber { get; set; }

        public int Email { get; set; }

        public DateTime LastVisit { get; set; }

        public string Explanation { get; set; }

        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }


    }
}
