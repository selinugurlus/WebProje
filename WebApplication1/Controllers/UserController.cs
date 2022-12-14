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
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserList()
        {
            var uservalues = um.GetUserList();
            return View(uservalues);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User u)
        {
            //um.UserAddBL(u);
            return RedirectToAction("GetUserList");
        }
    }
}