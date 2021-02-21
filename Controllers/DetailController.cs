using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang1.Models;

namespace WebBanHang1.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(String id)
        {
            Model3 db = new Model3();
            List<SP> sanPhams = db.SPs.Where(sp => sp.masp.Contains(id)).ToList();
            return View(sanPhams);
        }
    }
}