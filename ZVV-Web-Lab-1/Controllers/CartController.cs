using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_ZVV.Entities;
using DAL_ZVV.Interfaces;
using ZVV_Web_Lab_1.Models;

namespace ZVV_Web_Lab_1.Controllers
{
    public class CartController : Controller
    {
        private IRepository<LabGlassware> repository;

        public CartController()
        {
            //repository = new IRepository<LabGlassware>();
        }

        public CartController(IRepository<LabGlassware> repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns>Корзина из сесси или вновь созданная</returns>
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // GET: Cart
        public ActionResult Index(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(GetCart());
        }

        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="id">id добавляемого элемента</param>
        /// <param name="returnUrl">URL страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(int id, string returnUrl)
        {
            LabGlassware lgw = repository.Get(id);
            if (lgw != null) GetCart().AddItem(lgw);
            return Redirect(returnUrl);
        }
    }
}