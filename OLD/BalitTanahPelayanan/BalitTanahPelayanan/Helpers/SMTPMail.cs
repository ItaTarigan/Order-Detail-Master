// Decompiled with JetBrains decompiler
// Type: Gravicode.Library.Mail.SMTPMail
// Assembly: Gravicode.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F2F2284F-7FDC-4B0A-B842-2409BB212C2F
// Assembly location: D:\Downloads\Gravicode.Library.dll

using System.Net;
using System.Net.Mail;
using System.Web.Mail;

namespace Gravicode.Library.Mail
{
  public class SMTPMail
  {
    public static bool sendMail(
      string ServerMail,
      int Port,
      string pFrom,
      string pTo,
      string pSubject,
      string pBody,
      MailFormat pFormat,
      string pAttachmentPath,
      string username,
      string password)
    {
      try
      {
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        string str1 = pFrom;
        char[] chArray1 = new char[1]{ ';' };
        foreach (string address in str1.Split(chArray1))
        {
          MailAddress mailAddress = new MailAddress(address);
          message.From = mailAddress;
        }
        string str2 = pTo;
        char[] chArray2 = new char[1]{ ';' };
        foreach (string address in str2.Split(chArray2))
        {
          MailAddress mailAddress = new MailAddress(address);
          message.To.Add(mailAddress);
        }
        message.IsBodyHtml = pFormat == MailFormat.Html;
        message.Subject = pSubject;
        message.Body = pBody;
        if (!string.IsNullOrEmpty(pAttachmentPath))
        {
          Attachment attachment = new Attachment(pAttachmentPath);
          message.Attachments.Add(attachment);
        }
        SmtpClient smtpClient = new SmtpClient(ServerMail, Port);
        if (!string.IsNullOrEmpty(username))
        {
          smtpClient.UseDefaultCredentials = false;
          NetworkCredential networkCredential = new NetworkCredential(username, password);
          smtpClient.Credentials = (ICredentialsByHost) networkCredential;
        }
        smtpClient.Send(message);
        return true;
      }
      catch
      {
        throw;
      }
    }
  }
}
