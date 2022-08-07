using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    [Table("Sessao")]
    public class SessionModel : EntityBase
    {
        public virtual MovieTheaterModel MovieTheater { get; set; }

        public virtual MovieModel Movie { get; set; }

        public int MovieID { get; set; }

        public int MovieTheaterID { get; set; }

        public DateTime ClosingTime { get; set; }
    }
}
