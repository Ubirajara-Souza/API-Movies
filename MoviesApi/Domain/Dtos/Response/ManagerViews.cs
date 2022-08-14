using MoviesApi.Domain.Package;

namespace MoviesApi.Domain.Dtos.Response
{
    public class ManagerViews : EntityBase
    {
        public string Name { get; set; }

        public object MovieTheater { get; set; }
    }
}
