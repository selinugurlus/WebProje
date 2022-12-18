using BusinessLayer2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccesLayer.EntityFramework;

namespace WebApplication1.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentBySubject(int id) //konu başlıklarına göre ders notu içeriklerini getir.
        {
            var contentvalues = cm.GetListBySubjectID(id);
            return View(contentvalues);
        }
    }
}