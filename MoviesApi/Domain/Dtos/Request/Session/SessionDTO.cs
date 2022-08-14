using System;

namespace MoviesApi.Domain.Dtos.Request.Session
{
    public class SessionDTO
    {
        public int MovieID { get; set; }

        public int MovieTheaterID { get; set; }

        public DateTime ClosingTime { get; set; }
    }
}
