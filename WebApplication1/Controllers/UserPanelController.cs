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

namespace WebApplication1.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        SubjectManager sm = new SubjectManager(new EfSubjectDal());
        LessonManager lm = new LessonManager(new EfLessonDal());
        UserManager um = new UserManager(new EfUserDal());
        Context c = new Context();


        [HttpGet]
        public ActionResult UserProfile(int id=0)
        {
            
            string p = (string)Session["user_mail"];
            id = c.Userss.Where(x => x.user_mail == p).Select(y => y.user_id).FirstOrDefault();
            var uservalue = um.GetByID(id);
            return View(uservalue);
        }

        [HttpPost]
        public ActionResult UserProfile(User u)
        {
            UserValidator uservalidator = new UserValidator();
            ValidationResult results = uservalidator.Validate(u);
            if (results.IsValid)
            {
                um.UserUpdate(u);
                return RedirectToAction("AllSubject");
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

        public ActionResult MySubject(string p)
        {
               
            p = (string)Session["user_mail"];
            var useridinfo = c.Userss.Where(x => x.user_mail == p).Select(y => y.user_id).FirstOrDefault();
            var values = sm.GetSubjectListByUser(useridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSubject()
        {
          
            List<SelectListItem> valuelesson = (from x in lm.GetLessonList()
                                                select new SelectListItem
                                                {
                                                    Text = x.lesson_name,
                                                    Value = x.lesson_id.ToString()
                                                }).ToList();
            ViewBag.vll = valuelesson;
            return View();
        }

        [HttpPost]
        public ActionResult NewSubject(Subject s)
        {
            string usermailinfo = (string)Session["user_mail"];
            var useridinfo = c.Userss.Where(x => x.user_mail == usermailinfo).Select(y => y.user_id).FirstOrDefault();
            
            s.user_id = useridinfo;
            s.subject_status = true;
            sm.SubjectAdd(s);
            return RedirectToAction("MySubject");
        }


        [HttpGet]
        public ActionResult UpdateSubject(int id)
        {
            List<SelectListItem> valuelesson = (from x in lm.GetLessonList()
                                                select new SelectListItem
                                                {
                                                    Text = x.lesson_name,
                                                    Value = x.lesson_id.ToString()
                                                }).ToList();
            ViewBag.vll = valuelesson;
            var subjectvalue = sm.GetByID(id);
            return View(subjectvalue);
        }

        [HttpPost]
        public ActionResult UpdateSubject(Subject s)
        {
            sm.SubjectUpdate(s);
            return RedirectToAction("MySubject");
        }

        public ActionResult DeleteSubject(int id)
        {
            var subjectvalue = sm.GetByID(id);
            subjectvalue.subject_status = false;
            sm.SubjectDelete(subjectvalue);
            return RedirectToAction("MySubject");
        }

        [AllowAnonymous]
        public ActionResult AllSubject()
        {
            var subjects = sm.GetSubjectList();
            return View(subjects);
        }
    }
}