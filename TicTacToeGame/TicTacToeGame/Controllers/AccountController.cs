using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicTacToeGame.Models;
namespace TicTacToeGame.Controllers
{
    public class AccountController : Controller
    {
        UserContext db = new UserContext();
        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }
        public ActionResult Details() 
        {
            string name = null;
            if (User.Identity.IsAuthenticated)
            {
                if (name == null)
                {
                    name = User.Identity.Name.ToString();
                    var item = db.Users.Where(u => u.Name == name).FirstOrDefault();
                    if (item == null)
                    {
                        return HttpNotFound();
                    }
                    else 
                    {
                        return View(item);
                    }
                }
                
                
                return View("Error");
             /*   var item = db.Users.Where(u => u.Name == name).FirstOrDefault();
                if (item != null)
                {
                    return View(item);
                }
                else 
                {
                    return View("Error");
                }
               */ 
            }
            else 
            {
                return View("Login", "Account");
            }

        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else 
            {
                User user = null;
                using (UserContext db = new UserContext()) 
                {
                    user = db.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ModelState.AddModelError("","Такого пользователя нет");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model) 
        {
            if (!ModelState.IsValid) 
            {
                return null;
            }

            User user = null;
            using (UserContext db = new UserContext()) 
            {
                user = db.Users.FirstOrDefault(u => u.Name == model.Name);
               
            }
            if (user == null)
            {
                using (UserContext db = new UserContext())
                {
                    db.Users.Add(new Models.User { Email = model.Email, Name = model.Name, Password = model.Password });
                    db.SaveChanges();
                    user = db.Users.Where(u => u.Name == model.Name && u.Email == model.Email && u.Password == model.Password).FirstOrDefault();



                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");

                }
            }
            else 
            {
                ModelState.AddModelError("","Пользователь с такими данными уже есть");
            }
            return View(model);
        }
    }
}