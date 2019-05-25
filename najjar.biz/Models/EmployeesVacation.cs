using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class EmployeesVacation
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Last Modification Date")]
        public DateTime LastModificationDate { get; set; }

        [Required]
        [Display(Name = "Vacation Start Date")]
        public DateTime startDate { get; set; }

        [Display(Name = "Vacation End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Display(Name = "Status")]
        public String Status { get; set; }
        
        public int EmployeeId { get; set; }
    }
}