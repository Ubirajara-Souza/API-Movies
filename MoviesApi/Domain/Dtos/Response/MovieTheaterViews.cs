using MoviesApi.Domain.Package;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Domain.Dtos.Response
{
    public class MovieTheaterViews : EntityBase
    {
        public string Name { get; set; }

        public AddressModel Address { get; set; }

        public ManagerModel Manager { get; set; }
    }
}
