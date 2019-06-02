using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime ExpiresDate { get; set; }

        public Guid Token { get; set; }

        public int TestId { get; set; }

        public int EmployeeId { get; set; }

        // Navigation Properties...
        public Test Test { get; set; }

        public List<QuestionXDuration> QuestionXDurations { get; set; }

        public Employees Employee { get; set; }

        public List<TestXPaper> TestXPapers { get; set; }
    }
}