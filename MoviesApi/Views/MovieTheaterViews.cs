using MoviesApi.Models;

namespace MoviesApi.Views
{
    public class MovieTheaterViews : EntityBase
    {
        public string Name { get; set; }

        public AddressModel Address { get; set; }

        public ManagerModel Manager { get; set; }
    }
}
