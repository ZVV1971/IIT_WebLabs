using System.Web.Mvc;
using DAL_ZVV.Interfaces;
using DAL_ZVV.Entities;
using DAL_ZVV.Repositories;
using System.Web;

namespace ZVV_Web_Lab_1.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<LabGlassware> repository;

        public AdminController(IRepository<LabGlassware> repo)
        {
            repository = repo;
        }

        public AdminController()
        {
            repository = new EFLabGWRepository(new ApplicationDbContext());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(LabGlassware lgw,
             HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    int count = imageUpload.ContentLength;
                    lgw.GW_Picture = new byte[count];
                    imageUpload.InputStream.Read(lgw.GW_Picture, 0, count);
                    lgw.GW_MIMEType = imageUpload.ContentType;
                }
                try
                {
                    repository.Update(lgw);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(lgw);
                }
            }
            else return View(lgw);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new LabGlassware());
        }

        [HttpPost]
        public ActionResult Create(LabGlassware lgw, 
            HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    int count = imageUpload.ContentLength;
                    lgw.GW_Picture = new byte[count];
                    imageUpload.InputStream.Read(lgw.GW_Picture, 0, count);
                    lgw.GW_MIMEType = imageUpload.ContentType;
                }
                try
                {
                    repository.Create(lgw);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(lgw);
                }
            }
            else return View(lgw);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public ActionResult Delete(LabGlassware lgw)
        {
            try
            {
                repository.Delete(lgw.GW_ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(lgw);
            }
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }
    }
}