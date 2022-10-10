using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_mvc_demo.Controllers
{
    public class OrderSummaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
