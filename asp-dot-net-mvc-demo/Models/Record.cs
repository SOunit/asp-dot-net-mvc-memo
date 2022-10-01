using System.ComponentModel.DataAnnotations;

namespace asp_dot_net_mvc_demo.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}
