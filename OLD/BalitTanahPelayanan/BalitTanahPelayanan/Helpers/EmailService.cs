using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Net;
using BalitTanahPelayanan.Helpers.EmailSender;

namespace BalitTanahPelayanan.Helpers
{
    public class EmailService
    {
        /*
        //with sendgrid api
        public static bool SendEmail(string subject, string message, string toemail, bool IsHTML = true)
        {


            // Your gmail email address
            var FromEmail = ConfigurationManager.AppSettings["MailUser"];//"silpo@outlook.co.id";
            var apiKey = ConfigurationManager.AppSettings["SendGridKey"];


            try
            {
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(FromEmail, "SILPO - Balai Penelitian Tanah");

                var to = new EmailAddress(toemail);
                var plainTextContent = message;
                var htmlContent = IsHTML ? message : $"<strong>{message}</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = client.SendEmailAsync(msg).GetAwaiter().GetResult();
                return response.StatusCode == HttpStatusCode.Accepted;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("failed to send email with the following error:");
                //Console.WriteLine(ep.Message);
                LogHelpers.source = typeof(EmailService).ToString();
                LogHelpers.message = "failed to send email with the following error:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
                return false;
            }
        }
        */
        /*
        //with SMTP
        public static bool SendEmail(string subject, string message, string toemail,bool IsHTML=true)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Your gmail email address
            oMail.From = ConfigurationManager.AppSettings["MailUser"];//"silpo@outlook.co.id";

            // Set recipient email address
            oMail.To = toemail;

            // Set email subject
            oMail.Subject = subject;

            // Set email body
            if (IsHTML)
                oMail.HtmlBody = message;
            else
                oMail.TextBody = message;

            // Gmail SMTP server address
            SmtpServer oServer = new SmtpServer(ConfigurationManager.AppSettings["MailServer"]);//"SMTP.Office365.com"

            // If you want to use direct SSL 465 port,
            // please add this line, otherwise TLS will be used.
            // oServer.Port = 465;

            // set 587 TLS port;
            oServer.Port = int.Parse(ConfigurationManager.AppSettings["MailPort"]); //587;

            // detect SSL/TLS automatically
            oServer.ConnectType = SmtpConnectType.ConnectSTARTTLS;

            // Gmail user authentication
            // For example: your email is "gmailid@gmail.com", then the user should be the same
            oServer.User = ConfigurationManager.AppSettings["MailUser"];//"silpo@outlook.co.id";
            oServer.Password = ConfigurationManager.AppSettings["MailPassword"];//"Balittanah123";

            try
            {
                Console.WriteLine("start to send email over SSL ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("failed to send email with the following error:");
                //Console.WriteLine(ep.Message);
                LogHelpers.source = typeof(EmailService).ToString();
                LogHelpers.message = "failed to send email with the following error:"+ ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
                return false;
            }
        }*/
        //using outlook without EAMail
        public static bool SendEmail(string subject, string message, string toemail, bool IsHTML = true)
        {
            string smtpServer = "smtp-mail.outlook.com";
            
            var UserMail = ConfigurationManager.AppSettings["MailUser"];//"silpo@outlook.co.id";
            var UserPassword = ConfigurationManager.AppSettings["MailPassword"];//"Balittanah123";

            try
            {
                //Send teh High priority Email  
                EmailManager mailMan = new EmailManager(smtpServer);

                EmailSendConfigure myConfig = new EmailSendConfigure();
                // replace with your email userName  
                myConfig.ClientCredentialUserName = UserMail;
                // replace with your email account password
                myConfig.ClientCredentialPassword = UserPassword;
                myConfig.TOs = new string[] { toemail };
                myConfig.CCs = new string[] { };
                myConfig.From = UserMail;
                myConfig.FromDisplayName = "SILPO - Balai Penelitian Tanah";
                myConfig.Priority = System.Net.Mail.MailPriority.Normal;
                myConfig.Subject = subject;

                EmailContent myContent = new EmailContent();
                myContent.Content = message;
                myContent.IsHtml = IsHTML;
                mailMan.SendMail(myConfig, myContent);
                Console.WriteLine("email was sent successfully!");
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("failed to send email with the following error:");
                //Console.WriteLine(ep.Message);
                LogHelpers.source = typeof(EmailService).ToString();
                LogHelpers.message = "failed to send email with the following error:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
                return false;
            }
        }

    }

}