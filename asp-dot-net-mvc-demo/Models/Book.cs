using System.Collections.Generic;

namespace asp_dot_net_mvc_demo.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        // relationship
        public List<PersonBook> PersonsBooks { get; set; }
    }
}
