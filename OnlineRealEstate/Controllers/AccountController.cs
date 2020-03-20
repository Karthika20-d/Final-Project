using OnlineRealEstate.BL;
using OnlineRealEstate.Entity;
using OnlineRealEstate.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineRealEstate.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpModel signUpModel)
        {
            User user = new User();
            UserBL userBL = new UserBL();
            if (ModelState.IsValid)
            {
                user.Name = signUpModel.Name;
                user.Email = signUpModel.Email;
                user.PhoneNumber = signUpModel.PhoneNumber;
                user.Role = signUpModel.Role.ToString();
                user.Location = signUpModel.Location;
                user.Password = signUpModel.Password;
                if (userBL.SignUp(user) > 0)
                {
                    ViewBag.Message = "Register successfull";
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOut()
        {
             FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            User user = new User();
            UserBL userBL = new UserBL();
            if (ModelState.IsValid)
            {
                user.Email = loginModel.Email;
                user.Password = loginModel.Password;
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Email, false);
                    var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(loginModel);
                }
                //if (userBL.Login(user)=="Admin")
                //{
                //    return RedirectToAction("DisplayPropertyDetails","Property");
                //}
                //else if(userBL.Login(user) == "Buyer")
                //{
                //    ViewBag.Message = "Login successfull";
                //}
                //else
                //{
                //    ViewBag.Message = "Login failed";
                //}
            }
            return View();
        }
    }
}