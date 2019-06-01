using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class QuestionCategory
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }

        public List<Question> Questions { get; set; }
    }
}