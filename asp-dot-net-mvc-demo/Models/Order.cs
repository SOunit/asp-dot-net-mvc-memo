using System.Collections.Generic;

namespace asp_dot_net_mvc_demo.Models
{
	public class Order
	{
		public int Id { get; set; }

		public List<OrderItem> OrderItems { get; set; }

		// for post
		public Order()
		{
			this.OrderItems = new List<OrderItem>();
		}
	}
}
