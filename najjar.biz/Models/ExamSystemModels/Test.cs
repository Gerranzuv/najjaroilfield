using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DurationInMinutes { get; set; }
        
        public bool isActive { get; set; }

        public List<TestXQuestion> TestXQuestions { get; set; }

        public List<Registration> Registrations { get; set; }

        public int QuestionLimit { get; set; }

    }
}