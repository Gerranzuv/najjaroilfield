using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Language:BasicModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }


       
        [Display(Name = "Level")]
        public string Level { get; set; }


        public int EmployeeProspectId { get; set; }

        public EmployeeProspect EmployeePros { get; set; }
      
    }
}