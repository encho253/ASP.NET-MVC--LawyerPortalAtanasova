using LawyerTsvetelinaAtanasova.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LawyerTsvetelinaAtanasova.Controllers
{
    public class HomeController : Controller
    {
        #region "BG"
        public ActionResult Начало()
        {
           
            return View();
        }

        public ActionResult Услуги()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Профил()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Контакти()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TermsOfUseBG()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Контакти(ContactModel model)
        {
            var response = Request["g-recaptcha-response"];
            //secret that was generated in key value pair
            //const string secret = "6Lf1fAwTAAAAAHKz9xcJeA-1tD6WrjbhRwRIC4kM";

            string secret = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"];


            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret,
                        response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0)
                {
                    return View();
                }

                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        TempData["message"] = "The secret parameter is missing.";
                        break;
                    case ("invalid-input-secret"):
                        TempData["message"] = "The secret parameter is invalid or malformed.";
                        break;

                    case ("missing-input-response"):
                        TempData["message"] = "The response parameter is missing.";
                        break;
                    case ("invalid-input-response"):
                        TempData["message"] = "The response parameter is invalid or malformed.";
                        break;

                    default:
                        TempData["message"] = "Error occured. Please try again";
                        break;
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    SendContact(model.Name, model.Mobile, model.Email, model.Message);
                    TempData["message"] = "Съобщението е изпратено!";

                    return RedirectToAction("Контакти", "Home");

                }
            }
            return View();
        }


        private void SendContact(string name, int mobile, string email, string message)
        {
            SmtpClient SmtpServer = new SmtpClient();

            MailMessage recieverMail = new MailMessage();
            MailMessage senderMail = new MailMessage();

            #region "reciever"

            // Configure message for the reciever
            string emailRec = System.Web.Configuration.WebConfigurationManager.AppSettings["emailReceiver"];
            
            recieverMail.To.Add(emailRec);
       
            StringBuilder recieverMessage = new StringBuilder();
            recieverMessage.AppendLine("Име: " + name);
            recieverMessage.AppendLine("Телефон: " + mobile);
            recieverMessage.AppendLine("Емейл: " + email);
            recieverMessage.AppendLine("Съобщение: " + message);

            recieverMail.Subject = "Запитване";
            recieverMail.Body = recieverMessage.ToString();

            #endregion "reciever"

            #region "sender"

            // Configure back release message for the sender
            string senderEmail = email;
            senderMail.To.Add(senderEmail);
            //string senderMessage = "Вашето съобщение: " + message;
            senderMail.Subject = "Потвърждение за изпратено запитване към адвокат Атанасова";
            senderMail.Body = recieverMessage.ToString();

            #endregion "sender"

            SmtpServer.Send(recieverMail);
            SmtpServer.Send(senderMail);
        }
        #endregion

        #region "Deutch"
        public ActionResult StartSeite()
        {
            return View();
        }

        public ActionResult Rechtsgebiete()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Profil()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Kontakt()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TermsOfUseDE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kontakt(ContactModelDe model)
        {
            var response = Request["g-recaptcha-response"];
            //secret that was generated in key value pair
            //const string secret = "6Lf1fAwTAAAAAHKz9xcJeA-1tD6WrjbhRwRIC4kM";
            string secret = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"];


            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0)
                {
                    return View();
                }

                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        TempData["message"] = "The secret parameter is missing.";
                        break;
                    case ("invalid-input-secret"):
                        TempData["message"] = "The secret parameter is invalid or malformed.";
                        break;

                    case ("missing-input-response"):
                        TempData["message"] = "The response parameter is missing.";
                        break;
                    case ("invalid-input-response"):
                        TempData["message"] = "The response parameter is invalid or malformed.";
                        break;

                    default:
                        TempData["message"] = "Error occured. Please try again";
                        break;
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    SendContactDe(model.NameDe, model.MobileDe, model.EmailDe, model.MessageDe);
                    TempData["message"] = "Nachricht wurde gesendet!";
                    return RedirectToAction("Kontakt", "Home");
                }
            }
            return View();
        }


        private void SendContactDe(string nameDe, int mobileDe, string emailDe, string messageDe)
        {
            SmtpClient SmtpServer = new SmtpClient();
            MailMessage recieverMail = new MailMessage();
            MailMessage senderMail = new MailMessage();

            #region "reciever"

            // Configure message for the reciever
            string emailRec = System.Web.Configuration.WebConfigurationManager.AppSettings["emailReceiver"];
            
            recieverMail.To.Add(emailRec);

            StringBuilder str = new StringBuilder();
            str.AppendLine("Name: " + nameDe);
            str.AppendLine("Handy: " + mobileDe);
            str.AppendLine("E-Mail: " + emailDe);
            str.AppendLine("Nachricht: " + messageDe);

            recieverMail.Subject = "Запитване";
            recieverMail.Body = str.ToString();

            #endregion "reciever"

            #region "sender"

            // Configure back release message for the sender
            string senderEmail = emailDe;
            senderMail.To.Add(senderEmail);
            //string senderMessage = "Your message: " + messageDe;
            senderMail.Subject = "Ihre Nachricht wurde gesendet Anwalt Atanasova";
            senderMail.Body = str.ToString();

            #endregion "sender"

            SmtpServer.Send(recieverMail);
            SmtpServer.Send(senderMail);
        }

        #endregion

        #region "English"
        public ActionResult Index()
        {
           
            return View();
        }
      
        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TermsOfUseEN()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModelEn model)
        {
            var response = Request["g-recaptcha-response"];
            //secret that was generated in key value pair
            //const string secret = "6Lf1fAwTAAAAAHKz9xcJeA-1tD6WrjbhRwRIC4kM";
            string secret = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"];


            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0)
                {
                    return View();
                }

                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        TempData["message"] = "The secret parameter is missing.";
                        break;
                    case ("invalid-input-secret"):
                        TempData["message"] = "The secret parameter is invalid or malformed.";
                        break;

                    case ("missing-input-response"):
                        TempData["message"] = "The response parameter is missing.";
                        break;
                    case ("invalid-input-response"):
                        TempData["message"] = "The response parameter is invalid or malformed.";
                        break;

                    default:
                        TempData["message"] = "Error occured. Please try again";
                        break;
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    SendContactEn(model.NameEn, model.MobileEn, model.EmailEn, model.MessageEn);
                    TempData["message"] = "Message has been sent!";
                    return RedirectToAction("Contact", "Home");
                }
            }
            return View();
        }

       
        private void SendContactEn(string nameEn, int mobileEn, string emailEn, string messageEn)
        {
            SmtpClient SmtpServer = new SmtpClient();
            MailMessage recieverMail = new MailMessage();
            MailMessage senderMail = new MailMessage();

            #region "reciever"

            // Configure message for the reciever
            string emailRec = System.Web.Configuration.WebConfigurationManager.AppSettings["emailReceiver"];

            recieverMail.To.Add(emailRec);
         
            StringBuilder str = new StringBuilder();
            str.AppendLine("Name: " + nameEn);
            str.AppendLine("Mobile: " + mobileEn);
            str.AppendLine("Email: " + emailEn);
            str.AppendLine("Message: " + messageEn);

            recieverMail.Subject = "Запитване";
            recieverMail.Body = str.ToString();

            #endregion "reciever"

            #region "sender"

            // Configure back release message for the sender
            string senderEmail = emailEn;
            senderMail.To.Add(senderEmail);
            //string senderMessage = "Your message: " + messageEn;
            senderMail.Subject = "Your message has been sent tp lawyer Atanasova.";
            senderMail.Body = str.ToString();

            #endregion "sender"

            SmtpServer.Send(recieverMail);
            SmtpServer.Send(senderMail);
        }

        #endregion "EN"
          
    }
}