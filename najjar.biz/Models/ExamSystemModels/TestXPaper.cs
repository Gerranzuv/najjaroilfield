using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class TestXPaper
    {
        [Key]
        public int Id { get; set; }

        public int RegistrationId { get; set; }

        public int TestXQuestionId { get; set; }

        public int ChoiceId { get; set; }

        public string Answer { get; set; }

        public double MarkScored { get; set; }

        // Navigation Properties...

        public Choice Choice { get; set; }

        public Registration Registration { get; set; }

        public TestXQuestion TestXQuestion { get; set; }
    }
}