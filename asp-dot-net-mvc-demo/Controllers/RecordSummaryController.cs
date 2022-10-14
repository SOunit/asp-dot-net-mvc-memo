using System.Collections.Generic;
using System.Linq;
using asp_dot_net_mvc_demo.Data;
using asp_dot_net_mvc_demo.Models;
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

        public IActionResult GroupBy()
        {
            var recodrGroupByOrderBy = _db.Records
                .AsEnumerable()
                .GroupBy(r => r.IsCompleted)
                .Select(r => new RecordListGroupByIsCompleted
                {
                    Key = r.Key,
                    Records = r.ToList()
                });

            return View(recodrGroupByOrderBy);
        }

        public IActionResult GroupByOrderBy()
        {
            var recodrGroupByOrderBy = _db.Records
                .AsEnumerable()
                .GroupBy(r => r.IsCompleted)
                .Select(r => new RecordListGroupByIsCompleted
                {
                    Key = r.Key,
                    Records = r.ToList()
                })
                .OrderByDescending(r => r.Key);

            return View(recodrGroupByOrderBy);
        }
    }

    // FIXME: move this to better place
    public class RecordListGroupByIsCompleted
    {
        public bool Key { get; set; }

        public IList<Record> Records { get; set; }
    }
}
