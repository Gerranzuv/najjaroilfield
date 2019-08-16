using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class EmployeeProspect
    {


        [Key]
        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "LastModificationDate")]
        public DateTime LastModificationDate { get; set; }


        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public String Address { get; set; }

        [Required]
        [Display(Name = "Address In Arabic")]
        public String AddressInArabic { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ")]

        public String Email { get; set; }

        [Display(Name = "Employee image")]
        public string EmployeeImage { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public String Nationality { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Sex")]
        public String Sex { get; set; }

        [Required]
        [Display(Name = "Birth Place")]
        public String BirthPlace { get; set; }

        public List<WorkExperience> WorkExperiences { get; set; }

        

      
    }
}