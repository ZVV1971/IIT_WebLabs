using System.Web.Mvc;

namespace ZVV_Web_Lab_1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            return View();
        }
    }
}