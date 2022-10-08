using System.Linq;
using System.Threading.Tasks;
using asp_dot_net_mvc_demo.Data;
using asp_dot_net_mvc_demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_dot_net_mvc_demo.Controllers
{
    public class EntityFrameworkController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EntityFrameworkController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonCar()
        {
            var personList = _db.Persons
                .Include(p => p.Car)
                .Take(5)
                .ToList();
            return View(personList);
        }

        public IActionResult CreatePersonCar()
        {
            return View();
        }

        [HttpPost, ActionName("CreatePersonCar")]
        public async Task<IActionResult> CreatePersonCarPost()
        {
            var car = new Car()
            {
                Name = "Test Car"
            };

            await _db.Cars.AddAsync(car);

            await _db.SaveChangesAsync();

            var person = new Person()
            {
                Name = "Test Person",
                CarId = car.Id
            };

            await _db.Persons.AddAsync(person);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(this.PersonCar));
        }
    }
}
