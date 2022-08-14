using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Domain.Dtos.Request.MovieTheater
{
    public class MovieTheaterDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        public int AddressID { get; set; }
        public int ManagerID { get; set; }
    }
}
