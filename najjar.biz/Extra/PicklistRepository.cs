using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using najjar.biz.Context;
using najjar.biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace najjar.biz.Extra
{
    public class PicklistRepository
    {
        private static ApplicationDataContext db = new ApplicationDataContext();

        public static Picklist findPicklistByCode(string code) {
            return db.Picklists.Where(a => a.Code.Equals(code)).FirstOrDefault();
        }

        public static List<PicklistItem> findPickListItemsByPicklistCode(string code)
        {
            Picklist picklist=findPicklistByCode(code);
            return db.PicklistItems.Where(a => a.PicklistId.Equals(picklist.id)).ToList();
        }
       
    }
}