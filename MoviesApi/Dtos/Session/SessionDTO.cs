using System;

namespace MoviesApi.Dtos.Session
{
    public class SessionDTO
    {
        public int MovieID { get; set; }

        public int MovieTheaterID { get; set; }

        public DateTime ClosingTime { get; set; }
    }
}
