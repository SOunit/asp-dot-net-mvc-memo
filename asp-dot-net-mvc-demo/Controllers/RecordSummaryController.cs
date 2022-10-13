using System.Linq;
using asp_dot_net_mvc_demo.Data;
using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_mvc_demo.Controllers
{
    public class RecordSummaryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RecordSummaryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var recordGroupList = _db.Records
                .AsEnumerable()
                .GroupBy(r => r.IsCompleted);

            return View(recordGroupList);
        }
    }
}
