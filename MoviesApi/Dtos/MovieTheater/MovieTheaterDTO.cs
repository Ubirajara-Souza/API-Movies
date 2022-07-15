using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dtos.MovieTheater
{
    public class MovieTheaterDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
    }
}
