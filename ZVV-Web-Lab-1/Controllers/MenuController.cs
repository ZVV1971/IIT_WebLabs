using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZVV_Web_Lab_1.Models;

namespace ZVV_Web_Lab_1.Controllers
{
    public class MenuController : Controller
    {
        List<MenuItem> items;

        public MenuController()
        {
            items = new List<MenuItem> {
                new MenuItem { Name = "Домой", Controller = "Home", Action = "Index", Active = string.Empty },
                new MenuItem { Name = "Каталог", Controller = "Product", Action = "List", Active = string.Empty },
                new MenuItem { Name = "Администрирование", Controller = "Admin", Action = "Index", Active = string.Empty }
            };
        }

        public PartialViewResult Main()
        {
            return PartialView(items);
        }

        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        public string Side()
        { return "<span>Боковая панель</span>"; }

        public string Map()
        { return "<span>Карта сайта</span>"; }
    }
}