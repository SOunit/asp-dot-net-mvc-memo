using System;
using System.Threading.Tasks;
using asp_dot_net_mvc_demo.Data;
using asp_dot_net_mvc_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_mvc_demo.Controllers
{
    public class OrderSummaryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderSummaryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateSummaryOrder()
        {
            return View();
        }

        [HttpPost, ActionName("CreateSummaryOrder")]
        public async Task<IActionResult> CreateSummaryOrderPost()
        {
            // create guid
            var guid = Guid.NewGuid();

            for (int i = 0; i < 3; i++)
            {
                // create product
                var product1 = new Product()
                {
                    Name = "Order Summary - Product"
                };
                await _db.Products.AddAsync(product1);

                var product2 = new Product()
                {
                    Name = "Order Summary - Product"
                };
                await _db.Products.AddAsync(product2);

                // create order

                var order = new Order()
                {
                    SummaryId = guid
                };
                await _db.Orders.AddAsync(order);

                await _db.SaveChangesAsync();

                // create order item

                var orderItem1 = new OrderItem()
                {
                    OrderId = order.Id,
                    ProductId = product1.Id,
                    Quantity = 2
                };
                await _db.OrderItems.AddAsync(orderItem1);

                var orderItem2 = new OrderItem()
                {
                    OrderId = order.Id,
                    ProductId = product2.Id,
                    Quantity = 2
                };
                await _db.OrderItems.AddAsync(orderItem2);

                await _db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(this.Index));
        }
    }
}
