using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class EntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
