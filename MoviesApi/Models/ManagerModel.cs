using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesApi.Models
{

    [Table("Gerente")]
    public class ManagerModel : EntityBase
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<MovieTheaterModel> MovieTheater { get; set; }
    }
}
