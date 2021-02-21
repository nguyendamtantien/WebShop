using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang1.Models;

namespace WebBanHang1.Controllers
{
    public class UserController : Controller
    {
        Model3 db = new Model3();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid) {
                UserManager userManager = new UserManager();
                if (userManager.CheckMail(model.Email) && userManager.CheckUserName(model.UserName))
                {
                    User user = new User();
                    user.Email = model.Email;
                    user.UserName = model.UserName;
                    user.Password = userManager.EncryptPassword(model.Password);
                    user.sđt = model.sđt;
                    user.diachi = model.diachi;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Register", "Username is existed");
                    return View();
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["email"] = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                UserManager userManager = new UserManager();
                var f_password = userManager.EncryptPassword(user.Password);
                var data = db.Users.Where(s => s.Email.Equals(user.Email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["email"] = user.Email;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Login", "Login Fail");
                    return View();
                }
            }
            return View();
        }
    }
}