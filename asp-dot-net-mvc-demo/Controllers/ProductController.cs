using asp_dot_net_mvc_demo.Data;
using asp_dot_net_mvc_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_mvc_demo.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ProductController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			var products = _db.Products;
			return View(products);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product product)
		{
			if (ModelState.IsValid)
			{
				_db.Products.Add(product);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(product);
		}
	}
}
