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
    public class AdminLessonController : Controller
    {
        LessonManager lm = new LessonManager(new EfLessonDal());
       
        public ActionResult Index()
        {
            var lessonvalues = lm.GetLessonList();
            return View(lessonvalues);
        }

        [HttpGet]
        public ActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLesson(Lesson l)
        {
            LessonValidator lessonvalidator = new LessonValidator();
            ValidationResult results = lessonvalidator.Validate(l);
            if(results.IsValid)
            {
                lm.LessonAdd(l);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }

        public ActionResult DeleteLesson(int id)
        {
            var lessonvalue = lm.GetByID(id);
            lm.LessonDelete(lessonvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateLesson(int id)
        {
            var lessonvalue = lm.GetByID(id);
            return View(lessonvalue);
        }

        [HttpPost]
        public ActionResult UpdateLesson(Lesson l)
        {
            lm.LessonUpdate(l);
            return RedirectToAction("Index");
        }
    }
}