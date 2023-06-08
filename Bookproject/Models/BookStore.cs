namespace LookProject.Models
{
    public class BookStore
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public Store Store { get; set; }
    }
}
