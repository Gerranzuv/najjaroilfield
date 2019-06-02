using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class QuestionXDuration
    {
        [Key]
        public int Id { get; set; }

        public int RegistrationId  {get;set;}

        public int TestXQuestionId { get; set; }

        public DateTime RequestTime { get; set; }

        public DateTime LeaveTime { get; set; }

        public DateTime AnsweredTime { get; set; }


        // Navigation Properties...
        public Registration Registration { get; set; }

        public TestXQuestion TestXQuestion { get; set; }
    }
}