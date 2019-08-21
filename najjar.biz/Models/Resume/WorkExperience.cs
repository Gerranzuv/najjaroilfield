using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class WorkExperience:BasicModel
    {


        


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "From")]
        public DateTime From { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "To")]
        public DateTime To { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        public int EmployeeProspectId { get; set; }

        public EmployeeProspect EmployeePros { get; set; }

        public List<Certification> WorkExperiences { get; set; }
    }
}