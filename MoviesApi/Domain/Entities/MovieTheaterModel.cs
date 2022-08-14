using MoviesApi.Domain.Package;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesApi.Domain.Entities
{
    [Table("Cinema")]
    public class MovieTheaterModel : EntityBase
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        
        public virtual AddressModel Address { get; set; }

        public int AddressID { get; set; }
     
        public virtual ManagerModel Manager { get; set; }

        public int ManagerID { get; set; }

        [JsonIgnore]
        public virtual List<SessionModel> Session { get; set; }
    }
}
