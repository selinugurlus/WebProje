using BusinessLayer2.Concrete;
using BusinessLayer2.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer1.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserLoginManager ulm =new UserLoginManager(new EfUserDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin a)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.admin_username == a.admin_username &&
                x.admin_password == a.admin_password); //firstordefault geriye sadece bir değer döndürme işlemini yapıyor
            if(adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.admin_username, false);
                Session["admin_username"] = adminuserinfo.admin_username;
                return RedirectToAction("Index", "AdminLesson");
            }
            else
            {
                Response.Write("<script language='javascript'>alert(\"Hatalı Kullanıcı Adı veya Şifre Girdiniz\")</script>");
                return RedirectToAction("Index");
                
            }
            
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User a)
        {
            //    Context c = new Context();
            //    var useruserinfo = c.Userss.FirstOrDefault(x => x.user_mail== a.user_mail &&
            //        x.user_password == a.user_password); //firstordefault geriye sadece bir değer döndürme işlemini yapıyor
            var useruserinfo = ulm.GetUser(a.user_mail, a.user_password);
        if (useruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(useruserinfo.user_mail, false);
                Session["user_mail"] = useruserinfo.user_mail;
                return RedirectToAction("MyContent", "UserPanelContent");
            }
            else
            {
                Response.Write("<script language='javascript'>alert(\"Hatalı Kullanıcı Adı veya Şifre Girdiniz\")</script>");
                return RedirectToAction("UserLogin");

            }
           
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Subjects", "Default");
        }

        [HttpGet]
        public ActionResult UserRegister()
        {

            return View();
        }


        [HttpPost]
        public ActionResult UserRegister(User u)
        {
            UserManager um = new UserManager(new EfUserDal());
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(u);
            if (results.IsValid)
            {
                um.UserAdd(u);
                //u.user_status = true;
                return RedirectToAction("UserLogin");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();

        }
    }
}