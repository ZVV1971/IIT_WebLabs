using System.Web.Mvc;
using DAL_ZVV.Entities;
using DAL_ZVV.Interfaces;

namespace ZVV_Web_Lab_1.Controllers
{
    public class GWController : Controller
    {
        IRepository<LabGlassware> repository;

        public GWController(IRepository<LabGlassware> repo)
        {
            repository = repo;
        }

        public GWController()
        {
        }

        public ActionResult List()
        {
            return View(repository.GetAll());
        }
    }
}