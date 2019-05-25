using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class ArticleComment
    {
        [Key]
        public int id { get; set; }


        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }



        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        public int Articleid { get; set; }


    }
}