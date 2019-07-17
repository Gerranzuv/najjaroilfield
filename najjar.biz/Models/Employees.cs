﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace najjar.biz.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "EId")]
        public string EId { get; set; }

        [Display(Name = "Last Modification Date")]
        public DateTime lastModificationDate { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime creationDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Birth Place")]
        public String BirthPlace { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public String MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }

        [Display(Name = "Fixed Number")]
        public String FixedNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ")]

        public String Email { get; set; }


        [Required]
        [Display(Name = "Address")]
        public String Address { get; set; }


        [Required]
        [Display(Name = "Address In Arabic")]
        public String AddressInArabic { get; set; }

        [Required]
        [Display(Name = "Military Service")]
        public String militaryService { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date ")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Basic Salary ")]
        public double BasicSalary { get; set; }

        [Display(Name = "Trasport  Allowance")]
        public Double TrasportAllowance { get; set; }

        [Display(Name = "Housing Allowance ")]
        public double HousingAllowance { get; set; }


        [Display(Name = "Food Allowance ")]
        public Double FoodAllowance { get; set; }

        [Required]
        [Display(Name = "Total Salary ")]
        public double TotalSalary { get; set; }


        [Display(Name = "Type of Employee ")]
        public String TypeOfEmployee { get; set; }


        [Display(Name = " Transfere Method ")]
        public String SalaryTrasfereMethod { get; set; }

        [Display(Name = " Trasfere Destination ")]
        public String SalaryTransfereDestination { get; set; }

        [Required]
        [Display(Name = "Status ")]
        public String Status { get; set; }

        [Required]
        [Display(Name = "Department ")]
        public String Department { get; set; }

        [Required]
        [Display(Name = "DirectManager")]
        public String DirectManager { get; set; }

        [Display(Name = "Termination Reason ")]
        public String TerminationReason { get; set; }

        [Display(Name = "Termination Date ")]
        public DateTime TerminationDate { get; set; }

        [Display(Name = "Termination Mode ")]
        public String TerminationMode { get; set; }

        

        [Display(Name = "Employee image")]
        public string EmployeeImage { get; set; }

        [Display(Name = "Location")]
        public String Location { get; set; }

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

        public List<Registration> Registrations { get; set; }

        [Display(Name = "Monthly Salary ")]
        public Double MonthlySalary { get; set; }

        [Display(Name = "Org.Unit")]
        public String OrgUnit { get; set; }

        [Display(Name = "Work Schedule")]
        public String WorkSchedule { get; set; }

        [Display(Name = "Personal Area")]
        public String PersonalArea { get; set; }

        [Display(Name = "Cost Center ")]
        public Double CostCenter { get; set; }

        [Display(Name = "Telephone,Fax Expenses ")]
        public Double TelephoneFaxExpenses { get; set; }

        [Display(Name = "Others")]
        public Double Others { get; set; }

        [Display(Name = "Reloc Allow No Tax")]
        public Double RelocAllowNoTax { get; set; }

        [Display(Name = "Miscellaneous Deductions")]
        public Double MiscellaneousDeductions { get; set; }

        [Display(Name = "DSPP")]
        public Double DSPP { get; set; }

        [Display(Name = "Net Pay")]
        public Double NetPay { get; set; }

        [Display(Name = "Total Earnings")]
        public Double TotalEarnings { get; set; }

        [Display(Name = "Total Deductions")]
        public Double TotalDeductions { get; set; }

        [Display(Name = "MESSAGES")]
        public String MESSAGES { get; set; }


        [Display(Name = "A/C Number")]
        public Double AccountNumber { get; set; }

        [Display(Name = "Currency Paid In")]
        public String CurrencyPaidIn { get; set; }


        [Display(Name = "Exhange Rate")]
        public Double ExhangeRate { get; set; }


        [Display(Name = "Contract")]
        public String Contract { get; set; }
    }
}
