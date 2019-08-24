﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using najjar.biz.Context;
using najjar.biz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace najjar.biz.Extra
{
    public class UserVerificationHelper : Controller
    {
        private static ApplicationDataContext db = new ApplicationDataContext();
        public static string GenerateCode()
        {
            List<char> chars = new List<char>();
 
            chars.AddRange(GetLowerCaseChars(4));
            chars.AddRange(GetNumericChars(4));
 
            return GenerateCodeFromList(chars);
        }
 
        private static List<char> GetLowerCaseChars(int count)
        {
            List<char> result = new List<char>();
 
            Random random = new Random();
 
            for (int index = 0; index < count; index++)
            {
                result.Add(Char.ToLower(Convert.ToChar(random.Next(97, 122))));
            }
 
            return result;
        }
 
        private static List<char> GetNumericChars(int count)
        {
            List<char> result = new List<char>();
 
            Random random = new Random();
 
            for (int index = 0; index < count; index++)
            {
                result.Add(Convert.ToChar(random.Next(0, 9).ToString()));
            }
 
            return result;
        }
 
        private static string GenerateCodeFromList(List<char> chars)
        {
            string result = string.Empty;
 
            Random random = new Random();
 
            while (chars.Count > 0)
            {
                int randomIndex = random.Next(0, chars.Count);
                result += chars[randomIndex];
                chars.RemoveAt(randomIndex);
            }
 
            return result;
        }

        public static VerificationResult generateVerificationLog(string userId, String email)
        {
            UserVerificationLog log=new UserVerificationLog();
            log.Code=GenerateCode();
            log.CreationDate=DateTime.Now;
            log.ExpiryDate=DateTime.Now.AddHours(2);
            log.LastModificationDate=DateTime.Now;
            log.Status="NOT_CONFIRMED";
            log.UserId=userId;
            log.Email=email;
            log.IsEmailSent=sendEmail(log.Code,email);
            db.UserVerificationLogs.Add(log);
            VerificationResult result = new VerificationResult();

            try
            {
                db.SaveChanges();
                result.status = "200";
                result.message = "Code is sent, it's valid for two hours!";
                return result;
            }
            catch (DbEntityValidationException e)
            {
                string message1 = e.StackTrace;
                foreach (var eve in e.EntityValidationErrors)
                {

                    message1 += eve.Entry.State + "\n";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        message1 += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        message1 += "\n";
                    }
                }
                result.status = "500";
                result.message = message1;
                return result;
            }
        }
        private static bool sendEmail(String code, String email)
        {
            var _isOnProcuctionParameter = ParameterRepository.findByCode("is_on_production");
            Int32 isOnProcuctionParameter = Int32.Parse(_isOnProcuctionParameter);

            if (isOnProcuctionParameter==1)
            {
                String subject = "Verfication Code for Najjar Oil Field Account";
                String body = "Please use the following code to register to our website " + code;
                List<string> receivers = new List<string>();
                receivers.Add(email);
                EmailHelper.sendEmail(receivers, subject, body);
                return true;
            }
            return false;
        }

        public static VerificationResult reSendVerificationLog(string userId, String email)
        {
            VerificationResult result = new VerificationResult();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDataContext()));
            if (userManager.IsInRole(userId, "Guest"))
            {
                result.addError("User is already verified!");
                return result;
            }
            List<UserVerificationLog> oldLogs = db.UserVerificationLogs.Where(a => a.UserId.Equals(userId)
                && a.Status.Equals("NOT_CONFIRMED")).ToList();
            if (oldLogs.Count >= 10) {
                result.addError("Reached Code Limit");
                return result;
            }
            foreach (var item in oldLogs)
            {
                item.Status = "EXPIRED";
                item.LastModificationDate = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
            }
            return generateVerificationLog(userId, email);
        }

        public static VerificationResult verifyCode(string userId, String code)
        {
            VerificationResult result = new VerificationResult();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDataContext()));
            if (userManager.IsInRole(userId, "Guest")) {
                result.addError("User is already verified!");
                return result;
            }
            UserVerificationLog currentLog = db.UserVerificationLogs.Where(a => a.UserId.Equals(userId)
                && a.Status.Equals("NOT_CONFIRMED") && a.Code.Equals(code)).FirstOrDefault() ;
           
                
            if (currentLog != null)
            {
                if (currentLog.ExpiryDate.CompareTo(DateTime.Now) < 0)
                {
                    result.addError("Code is expired, Request new one please!");
                    return result;
                }
                currentLog.ConfirmationDate = DateTime.Now;
                currentLog.Status = "CONFIRMED";
                currentLog.LastModificationDate = DateTime.Now;
                db.Entry(currentLog).State = EntityState.Modified;
                db.SaveChanges();
                assignUserToGuestRole(userId);
                result.addSuccess("Success");
            }
            else
            {
                result.addError("Code is wrong");
            }
            return result;
        }

        public static void assignUserToGuestRole(string userId)
        {
            var user = db.Users.Find(userId);
            var role=db.Roles.Where(a=>a.Name.Equals("Guest")).FirstOrDefault();
            user.Roles.Add(new IdentityUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            });

            db.SaveChanges();
        }

        public static void assignUserToRole(string userId, string roleName)
        {
            var user = db.Users.Find(userId);
            var role = db.Roles.Where(a => a.Name.Equals(roleName)).FirstOrDefault();
            user.Roles.Add(new IdentityUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            });

            db.SaveChanges();
        }

        public  class VerificationResult
        {
            public string status { get; set; }
            public string message { get; set; }

            public void addError(String message)
            {
                this.status = "500";
                this.message = message;
            }
            public void addSuccess(String message) {
                this.status = "200";
                this.message = message;
            }

        }
    }
}