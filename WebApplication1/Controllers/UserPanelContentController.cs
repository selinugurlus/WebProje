using BusinessLayer2.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UserPanelContentController : Controller
    {
        // GET: UserPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["user_mail"];
            var useridinfo = c.Userss.Where(x => x.user_mail == p).Select(y => y.user_id).FirstOrDefault();
            var contentvalues = cm.GetContentListByUser(useridinfo);
            return View(contentvalues);
            
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["user_mail"];
            var useridinfo = c.Userss.Where(x => x.user_mail == mail).Select(y => y.user_id).FirstOrDefault();
            p.user_id = useridinfo;
            p.content_status = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}