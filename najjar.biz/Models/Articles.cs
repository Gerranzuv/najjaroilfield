using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Articles
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Title Of the news")]
        public string title { get; set; }
        [Required]
        [MaxLength(250)]
        [Display(Name = "Summary Of the news")]
        public string summary { get; set; }
        [Required]
        [Display(Name = "Description Of the news")]
        public string description { get; set; }

        public string attachment { get; set; }

        [Display(Name = "Date of puplishing")]
        public DateTime Date { get; set; }
        public int example { get; set; }
    }
}