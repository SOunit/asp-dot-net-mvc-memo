using asp_dot_net_mvc_demo.Data;
using asp_dot_net_mvc_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_mvc_demo.Controllers
{
    public class RecordController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RecordController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var records = _db.Records;
            return View(records);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Record record)
        {
            if (ModelState.IsValid)
            {
                _db.Records.Add(record);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(record);

        }
    }
}
