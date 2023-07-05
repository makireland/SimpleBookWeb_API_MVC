using System.ComponentModel.DataAnnotations;

namespace SimpleBookWeb.Domain.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
