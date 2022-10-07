using System.ComponentModel.DataAnnotations.Schema;

namespace asp_dot_net_mvc_demo.Models
{
	public class OrderItem
	{
		public int Id { get; set; }

		public int Quantity { get; set; }

		[ForeignKey("OrderId")]
		public int OrderId { get; set; }
		public Order Order { get; set; }

		[ForeignKey("ProductId")]
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
