using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Domain.Dtos.Request.MovieTheater
{
    public class UpdateMovieTheaterDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
    }
}
