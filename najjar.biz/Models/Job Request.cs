using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class JobRequest
    {
        [Key]
        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "LastModificationDate")]
        public DateTime LastModificationDate { get; set; }

        public int JobId { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Display(Name = "FilePath")]
        public string FilePath { get; set; }

        public string jobName { get; set; }

    }
}