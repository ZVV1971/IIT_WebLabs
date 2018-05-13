using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZVV_Web_Lab_1.Controllers
{
    public class MenuController : Controller
    {
        public string Main()
        { return "<span>Главное меню</span>"; }

        public string UserInfo()
        {return "<span>Меню пользователя </span>"; }

        public string Side()
        { return "<span>Боковая панель</span>"; }

        public string Map()
        { return "<span>Карта сайта</span>"; }

    }
}