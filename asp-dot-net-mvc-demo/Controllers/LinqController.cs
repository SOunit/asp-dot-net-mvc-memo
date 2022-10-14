using System.Collections.Generic;
using System.Linq;
using asp_dot_net_mvc_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_mvc_demo.Controllers
{
    public class LinqController : Controller
    {
        public IActionResult Index()
        {
            List<Product> productList = new List<Product>()
            {
                new Product
                {
                    Name = "Test1"
                },
                new Product
                {
                    Name = "Test2"
                },
                new Product
                {
                    Name = "Test3"
                },
                new Product
                {
                    Name = "Test4"
                },
            };

            var result = productList.Where(prd => prd.Name == "Test1");

            return View(result);
        }
    }
}
