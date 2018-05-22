using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZVV_Web_Lab_1.Models;
using DAL_ZVV.Interfaces;
using DAL_ZVV.Entities;
using DAL_ZVV.Repositories;

namespace ZVV_Web_Lab_1.Controllers
{
    public class MenuController : Controller
    {
        private List<MenuItem> items;
        private IRepository<LabGlassware> repository;

        public MenuController()
        {
            repository = new EFLabGWRepository(new ApplicationDbContext());
            items = new List<MenuItem> {
                new MenuItem { Name = "Домой", Controller = "Home", Action = "Index", Active = string.Empty },
                new MenuItem { Name = "Каталог", Controller = "GW", Action = "List", Active = string.Empty },
                new MenuItem { Name = "Администрирование", Controller = "Admin", Action = "Index", Active = string.Empty }
            };
        }

        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            MenuItem menuItem = items.FirstOrDefault(m => m.Controller == c);
            if (menuItem != null) menuItem.Active = "active";
            return PartialView(items);
        }

        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        public PartialViewResult Side()
        {
            IEnumerable<string> groups = repository
                                          .GetAll()
                                          .Select(selector: d => d.GW_Type)
                                          .Distinct();
            return PartialView(groups);
        }

        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}