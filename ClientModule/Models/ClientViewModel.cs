using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientModule.Models
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "!!!")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "!!!")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "!!!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "!!!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "!!!")]
        public string City { get; set; }

        [Required(ErrorMessage = "!!!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "!!!")]
        [Display(Name = "Postal Code")]
        public int PostCode { get; set; }

        [Required(ErrorMessage = "!!!")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "!!!")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        public IFormFile Image { get; set; }

        [Display(Name = "Image")]
        public byte[] ViewImage { get; set; }

        public string ContentType { get; set; }

        [Display(Name = "Last Visit")]
        public DateTime? LastVisit { get; set; }

        public string Explanation { get; set; }
    }
}
