using AutoMapper;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Session;
using MoviesApi.Domain.Entities;
using MoviesApi.Infra.Repositories;

namespace MoviesApi.Services
{
    public class SessionService
    {
        private SessionRepository _sessionRepository;
        private readonly IMapper _mapper;

        public SessionService(SessionRepository sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }

        public SessionViews AddSession(SessionDTO sessionDTO)
        {

            SessionModel session = _mapper.Map<SessionModel>(sessionDTO);
            _sessionRepository.AddSession(session);

            return _mapper.Map<SessionViews>(session);
        }

        public SessionViews ListSessionById(int id)
        {
            SessionModel session = _sessionRepository.ListSessionById(id);
            if (session != null)
            {
                SessionViews sessionViews = _mapper.Map<SessionViews>(session);
                return sessionViews;
            }
            return null;
        }

    }
}
