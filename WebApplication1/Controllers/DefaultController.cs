using BusinessLayer2.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        SubjectManager sm = new SubjectManager(new EfSubjectDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        
        public ActionResult Subjects()
        {
            var subjectlist = sm.GetSubjectList();
            return View(subjectlist);
        }
        
        public PartialViewResult Index(int id)
        {
            var contentlist = cm.GetListBySubjectID(id);
            return PartialView(contentlist);
        }
    }
}