using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace najjar.biz.ViewModels
{
    public class ChoiceModel
    {
        public int ChoiceId { get; set; }
        public string IsChecked { get; set; }

    }

    public class AnswerModel
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public Guid Token { get; set; }
        public string Direction { get; set; }
        public List<ChoiceModel> UserSelectedChoices { get; set; }

        public int count { get; set; }

        // In Case The Exam System supports Text Area Question-Type
        // public string Answer {get;set;}

        public List<int> UserSelectedId
        {
            get
            {
                return UserSelectedChoices == null ? new List<int>() :
                    UserSelectedChoices
                    .Where(x => x.IsChecked == "on" ||
                    "true".Equals(x.IsChecked, StringComparison.InvariantCultureIgnoreCase))
                    .Select(x => x.ChoiceId)
                    .ToList();
            }
        }
    }
}