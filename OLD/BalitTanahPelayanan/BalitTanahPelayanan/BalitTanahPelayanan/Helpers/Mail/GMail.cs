// Decompiled with JetBrains decompiler
// Type: Gravicode.Library.Mail.GMail
// Assembly: Gravicode.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F2F2284F-7FDC-4B0A-B842-2409BB212C2F
// Assembly location: D:\Downloads\Gravicode.Library.dll

using System;
using System.Web.Mail;

namespace Gravicode.Library.Mail
{
  public class GMail
  {
    public static bool SendEmail(
      string pGmailEmail,
      string pGmailPassword,
      string pTo,
      string pSubject,
      string pBody,
      MailFormat pFormat,
      string pAttachmentPath)
    {
      try
      {
        MailMessage message = new MailMessage();
        message.Fields.Add((object) "http://schemas.microsoft.com/cdo/configuration/smtpserver", (object) "smtp.gmail.com");
        message.Fields.Add((object) "http://schemas.microsoft.com/cdo/configuration/smtpserverport", (object) "465");
        message.Fields.Add((object) "http://schemas.microsoft.com/cdo/configuration/sendusing", (object) "2");
        message.Fields.Add((object) "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", (object) "1");
        message.Fields.Add((object) "http://schemas.microsoft.com/cdo/configuration/sendusername", (object) pGmailEmail);
        message.Fields.Add((object) "http://schemas.microsoft.com/cdo/configuration/sendpassword", (object) pGmailPassword);
        message.Fields.Add((object) "http://schemas.microsoft.com/cdo/configuration/smtpusessl", (object) "true");
        message.From = pGmailEmail;
        message.To = pTo;
        message.Subject = pSubject;
        message.BodyFormat = pFormat;
        message.Body = pBody;
        if (pAttachmentPath.Trim() != "")
        {
          MailAttachment mailAttachment = new MailAttachment(pAttachmentPath);
          message.Attachments.Add((object) mailAttachment);
          message.Priority = MailPriority.High;
        }
        SmtpMail.SmtpServer = "smtp.gmail.com:465";
        SmtpMail.Send(message);
        return true;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
