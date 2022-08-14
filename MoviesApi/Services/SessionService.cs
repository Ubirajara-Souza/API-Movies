using AutoMapper;
using MoviesApi.Database;
using MoviesApi.Dtos.Session;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Linq;

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

        public SessionViews AddSession(SessionDTO sessionDTO)
        {

            SessionModel session = _mapper.Map<SessionModel>(sessionDTO);
            _context.Session.Add(session);
            _context.SaveChanges();

            return _mapper.Map<SessionViews>(session);
        }

        public SessionViews ListSessionById(int id)
        {
            SessionModel session = _context.Session.FirstOrDefault(session => session.Id == id);
            if (session != null)
            {
                SessionViews sessionViews = _mapper.Map<SessionViews>(session);
                return sessionViews;
            }
            return null;
        }

    }
}
