using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        // Points Assigned to the Question
        public double points { get; set; }

        // The type of Question (Single Choice, Multiple Choice, Text Area...)
        public string QuestionType { get; set;}

        public string QuestionText { get; set; }

        public bool IsActive { get; set; }

        // Navigation Properties...

        // Every Question belongs to a property
        public QuestionCategory QuestionCategory { get; set; }

        // Every Test Contains Multiple Questions, and Every Question might belong to several Tests...
        public List<TestXQuestion> TestXQuestion { get; set; }

        public List<Choice> Choices { get; set; }
    }
}