using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class EmployeeProspect : BasicModel
    {


       
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

        public int EmployeeId {get;set;}

        public Employees Employee { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public String MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }

        [Display(Name = "Fixed Number")]
        public String FixedNumber { get; set; }

        [Required]
        [Display(Name = "Military Service")]
        public String militaryService { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date ")]
        public DateTime StartDate { get; set; }

        

      
    }
}