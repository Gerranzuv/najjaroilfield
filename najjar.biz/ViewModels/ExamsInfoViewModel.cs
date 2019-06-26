using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace najjar.biz.ViewModels
{
    public class ExamsInfoViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public List<TestInfoModel> Tests { get; set; }
    }
}