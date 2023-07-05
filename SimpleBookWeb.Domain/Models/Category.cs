namespace SimpleBookWeb.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Category()
        {
            Books = new HashSet<Book>();
        }
    }
}
