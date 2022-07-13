using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Dtos
{
    public class MovieDTO
    {

        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Director { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "O campo Duração é obrigatório")]

        [Range(30, 360, ErrorMessage = "Duração do filme deve ter no mínimo 30 min e no máximo 360 min")]
        public int Duration { get; set; }
    }
}
