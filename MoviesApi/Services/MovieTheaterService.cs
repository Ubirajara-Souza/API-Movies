using AutoMapper;
using MoviesApi.Database;

namespace MoviesApi.Services
{
    public class MovieTheaterService
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public MovieTheaterService(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
