using Microsoft.AspNetCore.Mvc;

namespace SimpleBookWeb.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            return View();
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
