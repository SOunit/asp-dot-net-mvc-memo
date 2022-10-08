using System.ComponentModel.DataAnnotations.Schema;

namespace asp_dot_net_mvc_demo.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public Car Car { get; set; }
    }
}
