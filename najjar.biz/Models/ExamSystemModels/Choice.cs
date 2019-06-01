using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Choice
    {
        [Key]
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Label { get; set; }

        public double points { get; set; }

        public bool IsActive { get; set; }

        // Navigation Properties...

        public Question Question { get; set; }

        // A Class That will calculate the Final Result for the Employee...
        public List<TestXPaper> TestXPapers {get;set;}
    }
}