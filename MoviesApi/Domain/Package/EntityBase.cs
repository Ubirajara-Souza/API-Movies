using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Domain.Package
{
    public class EntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
