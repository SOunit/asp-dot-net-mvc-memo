using System.Collections.Generic;
using asp_dot_net_mvc_demo.Models;

namespace asp_dot_net_mvc_demo.Data.ViewModels
{
    public class UpdateOrderListVM
    {
        public List<Order> OrderList { get; set; }

        // for post, bind user input to VM

        public string TestString { get; set; }

        public List<UpdateOrderVM> UpdateOrderVMList { get; set; }
    }
}
