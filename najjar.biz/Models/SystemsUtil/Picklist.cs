using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace najjar.biz.Models
{
    public class Picklist : BasicModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

                
        [Display(Name = "Code")]
        public string Code { get; set; }

        public List<PicklistItem> items { get; set; }
      
    }
}