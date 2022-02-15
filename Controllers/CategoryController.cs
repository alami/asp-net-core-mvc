using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
