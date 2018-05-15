using System.Linq;
using System.Web.Mvc;
using DAL_ZVV.Entities;
using DAL_ZVV.Interfaces;
using DAL_ZVV.Repositories;
using ZVV_Web_Lab_1.Models;
using System.Collections.Generic;

namespace ZVV_Web_Lab_1.Controllers
{
    public class GWController : Controller
    {
        IRepository<LabGlassware> repository;
        int PageSize = 3;

        public GWController(IRepository<LabGlassware> repo)
        {
            repository = repo;
        }

        public GWController()
        {
            repository = new FakeRepository();
        }

        public ActionResult List(int page = 1)
        {
            IEnumerable<LabGlassware> lst = repository.GetAll().OrderBy(p => p.GW_Type);
            return View(PageListViewModel<LabGlassware>.CreatePage(lst, page, PageSize));
        }
    }
}