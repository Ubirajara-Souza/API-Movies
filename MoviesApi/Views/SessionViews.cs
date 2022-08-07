using MoviesApi.Models;
using System;

namespace MoviesApi.Views
{
    public class SessionViews : EntityBase
    {
        public MovieTheaterModel MovieTheater { get; set; }

        public MovieModel Movie { get; set; }

        public DateTime ClosingTime { get; set; }
        public DateTime StartTime { get; set; }
    }
}
