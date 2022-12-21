using BusinessLayer2.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager am=new AdminManager(new EfAdminDal());
      
        public ActionResult Index()
        {
            var adminvalues = am.GetAdminList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin a)
        {
            am.AdminAdd(a);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var adminvalue = am.GetByID(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin a)
        {
            am.AdminUpdate(a);
            return RedirectToAction("Index");
        }
    }
}