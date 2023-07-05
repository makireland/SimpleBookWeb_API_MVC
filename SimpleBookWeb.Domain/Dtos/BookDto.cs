using System.ComponentModel.DataAnnotations;

namespace SimpleBookWeb.Domain.Dtos

{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; } 
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        public DateTime Registration { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}
