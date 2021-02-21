using Newtonsoft.Json;
using WebBanHang1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebBanHang1.Controllers
{
    public class CartController : Controller
    {
        Model3 db = new Model3();
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(string masp, int sl, string ten, int gia)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.masp == masp))
                {
                    foreach (var item in list)
                    {
                        if (item.masp == masp)
                        {
                            item.sl += sl;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.masp = masp;
                    item.ten = ten ;
                    item.sl = sl;
                    item.gia = gia;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.masp = masp;
                item.ten = ten;
                item.sl = sl;
                item.gia = gia;
                var list = new List<CartItem>();
                list.Add(item);

                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdatedCart(string id, int newQuantity)
        {
            // tìm carditem muon sua
            List<CartItem> cart = Session["CartSession"] as List<CartItem>;
            CartItem updatedCart = cart.FirstOrDefault(m => m.masp == id);
            if (updatedCart != null)
            {
                updatedCart.sl = newQuantity;
            }
            return RedirectToAction("Index");

        }
        public ActionResult DeleteCart(int id)
        {
            List<CartItem> cart = Session["CartSession"] as List<CartItem>;
            CartItem deletedCart = cart.FirstOrDefault(m => m.sl == id);
            if (deletedCart != null)
            {
                cart.Remove(deletedCart);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult OrderProccess(FormCollection f)
        {
            List<CartItem> listcart = Session["CartSession"] as List<CartItem>;
            Hoa_Don bill = new Hoa_Don()
            {
                mahd = f["mahd"],
                ten_kh = f["customerName"],
                diachi = f["address"],
                ngaytao = DateTime.Now,
                trangthai = "Proccessing",
            };
            db.Hoa_Don.Add(bill);
            db.SaveChanges();
            foreach (CartItem cart in listcart)
            {
                SP_HD billDetail = new SP_HD()
                {
                    mahd = bill.mahd,
                    masp = cart.masp,
                    sl = cart.sl,
                    gia = cart.gia
                };
                db.SP_HD.Add(billDetail);
                db.SaveChanges();
            }
            Session.Remove(CartSession);
            return View("OrderProccess");
        }
    }
}