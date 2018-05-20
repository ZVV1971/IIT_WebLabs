using System.Linq;
using System.Web.Mvc;
using DAL_ZVV.Entities;
using DAL_ZVV.Interfaces;
using DAL_ZVV.Repositories;
using System.Collections.Generic;

namespace ZVV_Web_Lab_1.Controllers
{
    public class GWController : Controller
    {
        private IRepository<LabGlassware> repository;
        private readonly int PageSize = 3;

        public GWController(IRepository<LabGlassware> repo)
        {
            repository = repo;
        }

        public GWController()
        {
            repository = new EFLabGWRepository(new ApplicationDbContext());
        }

        public ActionResult List(string group, int page = 1)
        {
            IEnumerable<LabGlassware> lst = repository
                .GetAll().Where(d => group == null || d.GW_Type.Equals(group))
                .OrderBy(d => d.GW_Price);
            return View(Models.PageListViewModel<LabGlassware>.CreatePage(lst, page, PageSize));
        }
    }
}