using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang1.Models;

namespace WebBanHang1.Controllers
{
    public class HomeController : Controller
    {
        Model3 db = new Model3();
        public ActionResult Index()
        {
            List<SP> sanPhams = db.SPs.ToList(); 
            return View(sanPhams);
        }
        [ChildActionOnly]
        public ActionResult LoadCategory()
        {
            List<Loai_SP> loai_SPs = db.Loai_SP.ToList();
            return PartialView(loai_SPs);
        }

        public ActionResult Load_SP(String id)
        {
            List<SP> sps = db.SPs.Where(sp => sp.maloai==id).ToList();
            return View(sps);
        }
    }
}