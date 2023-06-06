using HocLapTrinhAspNet.Models;
using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace HocLapTrinhAspNet.Controllers
{
    public class AuthenticationController : Controller
    {
        UserRepository userRepository = new UserRepository();
        HocLapTrinhDbContext myDb = new HocLapTrinhDbContext();
        // GET: Authentication
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckOTP()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {

            return View();
        }

        public ActionResult ResetPassword(int id)
        {
            ViewBag.IdUser = id;
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePassword(FormCollection form)
        {
            string passwordNew = form["password"];
            string rePasswordNew = form["rePassword"];
            int id = Int32.Parse(form["idUser"]);
            if (passwordNew.Equals(rePasswordNew))
            {
                User user = myDb.Users.FirstOrDefault(x => x.UserId == id);
                user.Password = userRepository.md5(passwordNew);
                myDb.SaveChanges();
                return RedirectToAction("Index", new { msg = "5" });
            }
            else
            {
                ViewBag.mess = "Error";
                ViewBag.IdUser = id;
                return View("ResetPassword");
            }

        }

        [HttpPost]
        public ActionResult VerifyOTP(FormCollection form)
        {

            var otp = form["otp"];
            var otpcheck = (string)Session["Otp"];
            if (otp.Equals(otpcheck))
            {
                var user = (User)Session["RegisterUser"];
                userRepository.AddUser(user);
                return RedirectToAction("Index", new { msg = "1" });
            }
            ViewBag.mess = "Error";
            return View("CheckOTP");
        }

        [HttpPost]
        public ActionResult RePassword(FormCollection form)
        {

            var email = form["email"];
            var check = userRepository.getUserByEmail(email);
            if (check != null)
            {
                var password = check.Password;
                var idUser = check.UserId;
                string html = "Vui lòng nhấn vào link để reset mật khẩu : <a href='https://localhost:44359/Authentication/ResetPassword/" + idUser + "'>Tại đây</a>";
                var subject = "Lấy lại mật khẩu";
                sendMail(check.Email, html, subject);
                ViewBag.mess = "Success";
                return View("ForgotPassword");
            }
            ViewBag.mess = "Error";
            return View("ForgotPassword");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            bool checkEmailExist = userRepository.checkExistEmail(user.Email);
            if (checkEmailExist)
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
            else
            {
                user.RoleId = 2;
                var otp = RandomNumber(6);
                Session.Add("RegisterUser", user);
                Session.Add("Otp", otp);
                string html = "Mã xác thực OTP đăng ký của bạn là :  " + otp;
                sendMail(user.Email, html, "Xác thực đăng ký tài khoản");

                ViewBag.mess = "Success";
                return View("CheckOTP");
                /*userRepository.AddUser(user);
                return RedirectToAction("Index", new { msg = "1" });*/
            }

        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User userInformation = userRepository.CheckLogin(user);
            if (userInformation != null)
            {
                Session.Add("USER", userInformation);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", new { msg = "3" });
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("USER");
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public ActionResult UpdateProfile(User user)
        {
            userRepository.UpdateUser(user);
            return RedirectToAction("ProfileUser", new { mess = "Success" });
        }

        public ActionResult ProfileUser(string mess)
        {
            User user = (User)Session["USER"];
            ViewBag.User = userRepository.getUserByEmail(user.Email);
            ViewBag.mess = mess;
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePasswordPro(FormCollection form)
        {
            string passwordNew = form["password"];
            string rePasswordNew = form["rePassword"];
            int id = Int32.Parse(form["UserId"]);
            if (passwordNew.Equals(rePasswordNew))
            {
                User user = myDb.Users.FirstOrDefault(x => x.UserId == id);
                user.Password = userRepository.md5(passwordNew);
                myDb.SaveChanges();
                return RedirectToAction("ProfileUser", new { mess = "Success" });
            }
            else
            {
                return RedirectToAction("ProfileUser", new { mess = "Error" });
            }

        }

        //random chuỗi số bất kỳ
        public static string RandomNumber(int numberRD)
        {
            string randomStr = "";
            try
            {

                int[] myIntArray = new int[numberRD];
                int x;
                //that is to create the random # and add it to uour string
                Random autoRand = new Random();
                for (x = 0; x < numberRD; x++)
                {
                    myIntArray[x] = System.Convert.ToInt32(autoRand.Next(0, 9));
                    randomStr += (myIntArray[x].ToString());
                }
            }
            catch (Exception ex)
            {
                randomStr = "error";
            }
            return randomStr;
        }

        public void sendMail(string email, string body, string subject)
        {
            var formEmailAddress = ConfigurationManager.AppSettings["FormEmailAddress"].ToString();
            var formEmailDisplayName = ConfigurationManager.AppSettings["FormEmailDisplayName"].ToString();
            var formEmailPassword = ConfigurationManager.AppSettings["FormEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPost"].ToString();
            bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
            MailMessage message = new MailMessage(new MailAddress(formEmailAddress, formEmailDisplayName), new MailAddress(email));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(formEmailAddress, formEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enableSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }
    }
}