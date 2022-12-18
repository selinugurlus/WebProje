using DataAccesLayer.Concrete;
using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
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
    }
}