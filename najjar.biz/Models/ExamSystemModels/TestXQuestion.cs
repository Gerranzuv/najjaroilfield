using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class TestXQuestion
    {
        [Key]
        public int Id { get; set; }
        public int TestId { get; set; }

        // THe Question Identity
        public int QuestionId { get; set; }

        // The number of Question in the Test (1, 2, 3, ....)
        public int QuestionNumber { get; set; }

        public bool IsActive { get; set; }

        // Navigation Properties...
        public Question Question { get; set; }

        public Test Test { get; set; }

        public List<TestXPaper> TestXPapers { get; set; }

        public List<QuestionXDuration> QuestionXDurations { get; set; }
    }
}