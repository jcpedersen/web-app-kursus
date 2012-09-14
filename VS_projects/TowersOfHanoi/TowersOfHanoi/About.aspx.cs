using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace TowersOfHanoi
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendMail_Click(object sender, EventArgs e)
        {
            //tdb: Take the text from the text box

            //Test:
            var fromAddr = new MailAddress("jcpedersen@gmail.com", "Jens C Pedersen");
            var toAddr = new MailAddress("jcpedersen@gmail.com", "Til JCP");
            var replyTo = new MailAddress("jcpedersen@gmail.com", "Jens Chr. Pedersen");

            const string fromPassword = "jech91pe";
            const string subject = "Subject";
            const string body = "Kære Jens ...";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddr.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddr, toAddr)
            {
                Subject = subject,
                Body = body,
                ReplyTo = replyTo

            })
            {
                smtp.Send(message);
            }


        }
    }
}
