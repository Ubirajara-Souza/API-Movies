using MoviesApi.Infra.Repositories.BaseContext;
using MoviesApi.Domain.Entities;
using System.Linq;

namespace MoviesApi.Infra.Repositories
{
    public class SessionRepository
    {
        protected readonly MoviesApiContext _context;

        public SessionRepository(MoviesApiContext context)
        {
            _context = context;
        }

        public SessionModel AddSession(SessionModel session)
        {
            _context.Session.Add(session);
            _context.SaveChanges();
            
           return session;
        }
        public SessionModel ListSessionById(int id)
        {
            SessionModel session = _context.Session.FirstOrDefault(session => session.Id == id);
            if (session != null)
            {
                return session;
            }
            return null;
        }
    }
}
