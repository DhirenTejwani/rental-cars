using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Net.Mail;

/// <summary>
/// Summary description for EmailRelay
/// </summary>
public class EmailRelay
{
    

   public string smtpServer;
    public string userName ;
    public string password;


    public EmailRelay(string _smtpServer, string _userName, string _password)
    {
        smtpServer = _smtpServer;
        userName = _userName;
        password = _password;
    }

    public static bool ServerCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
        return sslPolicyErrors == System.Net.Security.SslPolicyErrors.None;
    }
    public bool SendMail(string fromAddress, string toAddress, string subject, string body, string fromEmailName, bool useSSL)
	{

		MailMessage mm = new MailMessage();
		SmtpClient smtp = new SmtpClient();
		MailAddress emailFrom = new MailAddress(fromAddress, fromEmailName);
		System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();

		try {
			NetworkCred.UserName = userName;
			// "yourRelayEmailAcct@gmail.com"
			NetworkCred.Password = password;

		
			mm.To.Add(new MailAddress(toAddress));
            mm.From = emailFrom;
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = true;

			 
             smtp.Host = smtpServer;
			// "smtp.gmail.com"
             smtp.EnableSsl = useSSL;
			// You can also add this in the webconfig
             smtp.UseDefaultCredentials = true;
             smtp.Credentials = NetworkCred;
             smtp.Port = 587;
             smtp.Send(mm);

		} catch (Exception ex) {
			//errMsg = ex.Message;
			return false;
		}

		return true;

	}

}
