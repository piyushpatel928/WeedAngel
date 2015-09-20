using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WeedAngel.Models.ViewModel
{
    public class MailVM
    {
        public bool WelcomeMail(string UserName, string MailTo)
        {
            if (MailTo != "")
            {
                try
                {

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("pratik5252552@gmail.com");
                    msg.To.Add(MailTo);
                    msg.Subject = "Welcome Regards";

                    string EmailMessage = "";


                    EmailMessage += "<b> Welcome to WeedAngels. </b>";

                    EmailMessage += "<br/> Your UserName : " + UserName + "<br/>";

                    EmailMessage += "<br/> <b> Thank You for Join WeedAngels. </b> " + "<br/>";

                    // EmailMessage += "<br/> Visit us : <a href='www.ulifesystems.com/contacts'> www.ulifesystems.com/contacts </a>" + "<br/>";

                    EmailMessage += "<br/> <b>  Best Regards </b>" + "<br/>";

                    EmailMessage += " <b> WeedAngels Teams. </b>";

                    msg.Body = EmailMessage;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("pratik5252552@gmail.com", "pratikshhr");
                    smtp.EnableSsl = true;

                    smtp.Send(msg);
                    return true;

                   
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }
        public bool FeedBackMessageSent(string Name, string Email, string FeedBackMessage)
        {

            try
            {
                string fromEmail = "support@sync2send.com";
                string toEmail = "support@sync2send.com";
                MailMessage message = new MailMessage(fromEmail, toEmail);
                message.Subject = "SocialTools Feedback Center";
                string EmailMessage = "";

                EmailMessage += " <br/> <b> Feedback Message from : </b> " + Name + "<br/>";

                EmailMessage += " <br/> <b>  Feedback Person Email Id : </b>" + Email + "<br/>";

                EmailMessage += " <br/> <b> Feedback Message : </b> " + FeedBackMessage + " <br/>";

                message.Body = EmailMessage;

                message.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtpout.secureserver.net"; // ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = false;//Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "support@sync2send.com"; //ConfigurationManager.AppSettings["UserName"];

                NetworkCred.Password = "Razorfish12"; //ConfigurationManager.AppSettings["Password"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 3535; //int.Parse(ConfigurationManager.AppSettings["Port"]);


                smtp.Send(message);
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}