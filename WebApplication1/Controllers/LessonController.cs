using BusinessLayer2.Concrete;
using BusinessLayer2.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer1.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LessonController : Controller
    {
      
        LessonManager lm = new LessonManager(new EfLessonDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLessonList()
        {
            var uservalues = lm.GetLessonList();
            return View(uservalues);
        }

        [HttpGet]
        public ActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLesson(Lesson l)
        {
            //um.UserAddBL(u);
            LessonValidator lessonValidator = new LessonValidator();
            ValidationResult results = lessonValidator.Validate(l);
            if (results.IsValid)
            {
                lm.LessonAdd(l);
                return RedirectToAction("GetLessonList");
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