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
    public class SubjectController : Controller
    {
        // GET: Subject
        SubjectManager sm = new SubjectManager(new EfSubjectDal());
        LessonManager lm = new LessonManager(new EfLessonDal());
        UserManager um = new UserManager(new EfUserDal());
        public ActionResult Index()
        {
            var subjectvalues = sm.GetSubjectList();
            return View(subjectvalues);
        }

        [HttpGet]
        public ActionResult AddSubject()
        {
            List<SelectListItem> valuelesson = (from x in lm.GetLessonList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.lesson_name,
                                                     Value = x.lesson_id.ToString()
                                                 }).ToList();
            ViewBag.vll = valuelesson;

            List<SelectListItem> valueuser = (from x in um.GetUserList()
                                                select new SelectListItem
                                                {
                                                    Text = x.user_name +" "+x.user_surname,
                                                    Value = x.user_id.ToString()
                                                }).ToList();
            ViewBag.vlu = valueuser;
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject s)
        {
            sm.SubjectAdd(s);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSubject(int id)
        {
            var subjectvalue = sm.GetByID(id);
            subjectvalue.subject_status = false;
            sm.SubjectDelete(subjectvalue);
            return RedirectToAction("Index");
        }


    }

}