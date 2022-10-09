namespace asp_dot_net_mvc_demo.Models
{
    public class PersonBook
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
