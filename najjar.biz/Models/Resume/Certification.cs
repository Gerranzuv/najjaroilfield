using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Certification:BasicModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Certification Date")]
        public DateTime CertificationDate { get; set; }


        [Display(Name = "University")]
        public string University { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        
      
    }
}