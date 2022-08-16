using System.ComponentModel.DataAnnotations;

namespace UserApi.Domain.Package
{
    public class EntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}

