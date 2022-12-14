using System.Linq;
using System.Threading.Tasks;
using asp_dot_net_mvc_demo.Data;
using asp_dot_net_mvc_demo.Data.ViewModels;
using asp_dot_net_mvc_demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_dot_net_mvc_demo.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _db.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product).ToListAsync();
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatePost()
        {
            var order = new Order { };

            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();

            var products = _db.Products.Take(5);

            foreach (var product in products)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = 3
                };
                await _db.OrderItems.AddAsync(orderItem);
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update()
        {
            var orderList = await _db.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product).ToListAsync();

            var updateOrderListVM = new UpdateOrderListVM();

            updateOrderListVM.OrderList = orderList;

            return View(updateOrderListVM);
        }

        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> UpdatePost(UpdateOrderListVM model)
        {
            foreach (var order in model.OrderList)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    var orderItemId = orderItem.Id;
                    var quantity = orderItem.Quantity;

                    var dbOrderItem = _db.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);

                    dbOrderItem.Quantity = quantity;

                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
