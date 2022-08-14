using MoviesApi.Domain.Package;

namespace MoviesApi.Domain.Dtos.Response
{
    public class MovieViews : EntityBase
    {
        public string Title { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        public int Duration { get; set; }
    }
}
