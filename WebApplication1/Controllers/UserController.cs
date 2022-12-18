using BusinessLayer2.Concrete;
using BusinessLayer2.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer1.Concrete;
using FluentValidation.Results;
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
        UserValidator userValidator = new UserValidator();

        public ActionResult Index()
        {
            var uservalues = um.GetUserList();
            return View(uservalues);
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
           
            ValidationResult results = userValidator.Validate(u);
            if (results.IsValid)
            {
                um.UserAdd(u);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var uservalue = um.GetByID(id);
            return View(uservalue);

        }

        [HttpPost]
        public ActionResult UpdateUser(User u)
        {
            ValidationResult results = userValidator.Validate(u);
            if (results.IsValid)
            {
                um.UserUpdate(u);
                return RedirectToAction("Index");
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