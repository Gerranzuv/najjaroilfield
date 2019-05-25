using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Job
    {


        [Key]
        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "LastModificationDate")]
        public DateTime LastModificationDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "AnnonDate")]
        public DateTime AnnouncementDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "ClosingDate")]
        public DateTime ClosingDate { get; set; }

      

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "MilitaryService")]
        public string MilitaryService { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Breifdescreption")]
        public string Breifdescreption { get; set; }

        [Required]
        [Display(Name = "Detaileddescreption")]
        public string Detaileddescreption { get; set; }

        [Required]
        [Display(Name = "jobRequierment")]
        public string jobRequierment { get; set; }

        [Required]
        [Display(Name = "AverageSalary")]
        public double AverageSalary { get; set; }

        

      
    }
}