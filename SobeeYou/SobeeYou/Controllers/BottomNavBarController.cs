using System.Net.Mail;
using System.Net;
using System.Web.Mvc;

namespace SobeeYou.Controllers
{
    public class BottomNavBarController : Controller
    {
        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string email, string message)
        {
            // TODO: Implement email sending functionality
            // Send email using the provided email and message
            string workEmail = "eyassu.million@gmail.com"; // replace with sobee email
            string fromPassword = "nkum abbn kcyz cvxs"; // replace with sobee app password

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(workEmail, fromPassword);

            // Create the password reset email
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(workEmail);
            mailMessage.To.Add(workEmail);
            mailMessage.Subject = "New Inquiry from Customer!";
            mailMessage.Body = "Here is a new message from " + email + ": " + message;

            // Send the email
            smtpClient.Send(mailMessage);
            TempData["SuccessMessage"] = "Your message to SoBee You has been sent! Please check your email for a reply within 1-2 business days.";
            return RedirectToAction("Contact");
        }

        public ActionResult ShippingReturns()
        {
            return View();
        }

        public ActionResult RefundPolicy()
        {
            return View();
        }

        public ActionResult TermsOfService()
        {
            return View();
        }
    }
}