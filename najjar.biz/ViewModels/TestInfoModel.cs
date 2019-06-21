using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace najjar.biz.ViewModels
{
    public class TestInfoModel
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public double MarkScored { get; set; }
        public double TotalMark { get; set; }

    }
}