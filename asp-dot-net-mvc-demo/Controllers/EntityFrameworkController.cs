using System.Collections.Generic;
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

        public IActionResult PersonsBooks()
        {
            var persons = _db.Persons
                .Include(p => p.PersonsBooks)
                .ThenInclude(pb => pb.Book).ToList();

            return View(persons);
        }

        public IActionResult CreatePersonsBooks()
        {
            return View();
        }

        [HttpPost, ActionName("CreatePersonsBooks")]
        public async Task<IActionResult> CreatePersonsBooksPost()
        {

            var newBooks = new List<Book>();
            var newPersons = new List<Person>();

            for (int i = 0; i < 3; i++)
            {
                var newBook = new Book()
                {
                    Title = "Title"
                };
                await _db.Books.AddAsync(newBook);
                await _db.SaveChangesAsync();

                var newCar = new Car()
                {
                    Name = "Name"
                };
                await _db.Cars.AddAsync(newCar);
                await _db.SaveChangesAsync();

                var newPerson = new Person()
                {
                    Name = "Name",
                    CarId = newCar.Id
                };
                await _db.Persons.AddAsync(newPerson);
                await _db.SaveChangesAsync();

                newBooks.Add(newBook);
                newPersons.Add(newPerson);
            }

            foreach (var person in newPersons)
            {
                foreach (var book in newBooks)
                {
                    var newPersonBook = new PersonBook()
                    {
                        PersonId = person.Id,
                        BookId = book.Id
                    };
                    await _db.PersonsBooks.AddAsync(newPersonBook);
                }
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(this.PersonsBooks));
        }
    }
}
