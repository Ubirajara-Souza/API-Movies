using AutoMapper;
using MoviesApi.Database;

namespace MoviesApi.Services
{
    public class SessionService
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public SessionService(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
