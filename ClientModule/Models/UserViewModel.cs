using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name="User Name")]
        public string UserName { get; set; }
        
       /* public string RoleId { get; set; }

        public string RoleName { get; set; }*/

        public RoleViewModel Role { get; set; }

    }
}
