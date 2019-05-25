using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class EmployeeRating
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Last Modification Date")]
        public DateTime LastModificationDate { get; set; }


        [Display(Name = "Year")]
        public String Year { get; set; }

        [Display(Name = "Rating")]
        public String Rating { get; set; }


        [Display(Name = "Status")]
        public String Status { get; set; }

        [Display(Name = "Salary before update")]
        public Double SalaryBeforeUpdate { get; set; }

        [Display(Name = "Salary after update")]
        public Double SalaryAfterUpdate { get; set; }
        
        public int EmployeeId { get; set; }
    }
}