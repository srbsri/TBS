using Microsoft.AspNetCore.Mvc;

namespace TBS.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
