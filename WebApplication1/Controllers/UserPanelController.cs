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
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        SubjectManager sm = new SubjectManager(new EfSubjectDal());
        LessonManager lm = new LessonManager(new EfLessonDal());
        public ActionResult UserProfile()
        {
            return View();
        }
       
        public ActionResult MySubject()
        {
           // id = 1;
            var values = sm.GetSubjectListByUser();
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
            s.user_id = 1;
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

    }
}