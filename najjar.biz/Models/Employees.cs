using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Employees
    {
        
       [Key]
       public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "EId")]
        public string EId { get; set; }

        
        [Display(Name = "Last Modification Date")]
        public DateTime lastModificationDate{ get; set; }

        
        [Display(Name = "Creation Date")]
        public DateTime creationDate{ get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate{ get; set; }

        [Required]
        [Display(Name = "Birth Place")]
        public String BirthPlace{ get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public String MaritalStatus{ get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public String PhoneNumber{ get; set; }


       
        [Display(Name = "Fixed Number")]
        public String FixedNumber{ get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ")]
       
        public String Email{ get; set; }


        [Required]
        [Display(Name = "Address")]
        public String Address{ get; set; }


        [Required]
        [Display(Name = "Address In Arabic")]        
        public String AddressInArabic{ get; set; }

        [Required]
        [Display(Name = "Military Service")]
        public String militaryService{ get; set; }

        [Required]
        [Display(Name = "Start Date ")]
        public DateTime StartDate{ get; set; }


       
        [Display(Name = "Basic Salary ")]
        public Double BasicSalary{ get; set; }


        
        [Display(Name = "Trasportation ")]
        public Double Trasportation{ get; set; }

       
        [Display(Name = "Housing Allowance ")]
        public Double HousingAllowance{ get; set; }

        
        [Display(Name = "Food Allowance ")]
        public Double FoodAllowance{ get; set; }

        [Required]
        [Display(Name = "Total Salary ")]
        public Double TotalSalary{ get; set; }

        
        [Display(Name = "Type of Employee ")]
        public String TypeOfEmployee{ get; set; }

       
        [Display(Name = " Transfere Method ")]
        public String SalaryTrasfereMethod{ get; set; }

        
        [Display(Name = " Trasfere Destination ")]
        public String SalaryTransfereDestination{ get; set; }

        [Required]
        [Display(Name = "Status ")]
        public String Status{ get; set; }

        [Required]
        [Display(Name = "Department ")]
        public String Department{ get; set; }

        [Required]
        [Display(Name = "DirectManager")]
        public String DirectManager{ get; set; }

        [Display(Name = "Termination Reason ")]
        public String TerminationReason{ get; set; }

        [Display(Name = "Termination Date ")]
        public DateTime TerminationDate{ get; set; }


        
        [Display(Name = "Employee image")]
        public string EmployeeImage { get; set; }

        [Display(Name = "Location")]
        public String Location { get; set; }


        [Required]
        [Display(Name = "Grade")]
        public int Grade { get; set; }


        [Required]
        [Display(Name = "Position")]
        public String position { get; set; }

        [Required]
        [Display(Name = "Country")]
        public String Country { get; set; }

        [Display(Name = "Employee Code")]
        public String EmployeeCode { get; set; }
    }
    }
