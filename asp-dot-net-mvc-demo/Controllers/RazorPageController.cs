using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_mvc_demo.Controllers
{
	public class RazorPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
