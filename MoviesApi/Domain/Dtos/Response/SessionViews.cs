using MoviesApi.Domain.Package;
using MoviesApi.Domain.Entities;
using System;

namespace MoviesApi.Domain.Dtos.Response
{
    public class SessionViews : EntityBase
    {
        public MovieTheaterModel MovieTheater { get; set; }

        public MovieModel Movie { get; set; }

        public DateTime ClosingTime { get; set; }
        public DateTime StartTime { get; set; }
    }
}
