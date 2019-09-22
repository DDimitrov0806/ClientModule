using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name="Role")]
        public string Name { get; set; }
    }
}
