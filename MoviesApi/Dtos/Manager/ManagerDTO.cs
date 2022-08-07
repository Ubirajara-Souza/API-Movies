using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dtos.Manager
{
    public class ManagerDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
    }
}
