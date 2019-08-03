using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace najjar.biz.Extra
{
    public class EmailHelper
    {
        public static void sendEmail(List<string> to,string subject,string body)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            m.From = new MailAddress("info@najjaroilfield.net");
            foreach (var item in to)
            {
                m.To.Add(item);
            }
            m.Subject = subject;
            m.Body = body;
            sc.Host = "mail5004.smarterasp.net";
            string str1 = "gmail.com";
            string str2 = "info@najjaroilfield.net";
            if (str2.Contains(str1))
            {
                try
                {
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential("info@najjaroilfield.net", "822357kenan$");
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
                    sc.Credentials = new System.Net.NetworkCredential("info@najjaroilfield.net", "822357kenan$");
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