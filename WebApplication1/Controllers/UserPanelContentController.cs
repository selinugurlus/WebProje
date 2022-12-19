using BusinessLayer2.Concrete;
using DataAccesLayer.EntityFramework;
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
        public ActionResult MyContent()
        {
            var contentvalues = cm.GetContentListByUser();
            return View(contentvalues);
            
        }
    }
}