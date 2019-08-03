using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace najjar.biz.Extra
{
    public class EmailHelper
    {
        public static void sendEmail(string to,string subject,string body)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            m.From = new MailAddress("postmaster@najjaroilfield.net");
            m.To.Add(to);
            m.Subject = subject;
            m.Body = body;
            sc.Host = "mail5004.smarterasp.net";
            string str1 = "gmail.com";
            string str2 = "info@najjaroilfield.com";
            if (str2.Contains(str1))
            {
                try
                {
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential("postmaster@najjaroilfield.net", "822357kenan$");
                    sc.EnableSsl = true;
                    sc.Send(m);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                try
                {
                    sc.Port = 25;
                    sc.Credentials = new System.Net.NetworkCredential("postmaster@najjaroilfield.net", "822357kenan$");
                    sc.EnableSsl = false;
                    sc.Send(m);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}