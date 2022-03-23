namespace MAK.LibEmail;

public class Email
{
    public static string EmailSubject
    {
        get; set;
    }
    public static string EmailBody
    {
        get; set;
    }
    public static string EmailUserPersonalDetails
    {
        get; set;
    }

    public static void SendEmail(string smtpServer, string mailServerUserName, string mailServerUserPassword, string toEmailAddress)
    {
        var mail = new MailMessage
        {
            IsBodyHtml = true,

            //IMPORTANT: This must be same as your smtp authentication address.
            From = new MailAddress(mailServerUserName)
        };

        mail.To.Add(toEmailAddress);
        mail.Subject = EmailSubject;
        mail.Body = EmailBody;

        var smtp = new SmtpClient(smtpServer);

        //IMPORANT:  Your smtp login email MUST be same as your FROM address.
        var Credentials = new NetworkCredential(mailServerUserName, mailServerUserPassword);

        smtp.UseDefaultCredentials = false;
        smtp.Credentials = Credentials;
        smtp.Port = 25;    // 25 or 8889
        smtp.EnableSsl = false;
        smtp.Send(mail);
    }
}
