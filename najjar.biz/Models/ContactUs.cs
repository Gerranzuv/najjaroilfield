using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class ContactUs
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required]
        [MaxLength(250)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        [Phone]
        public string PhoneNumber;

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }



        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}