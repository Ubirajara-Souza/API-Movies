using FluentResults;
using System.Threading.Tasks;
using UserApi.Infra.Repositories;

namespace UserApi.Services
{
    public class LogoutService
    {
        private LogoutRepository _logoutRepository;

        public LogoutService(LogoutRepository logoutRepository)
        {
            _logoutRepository = logoutRepository;

        }

        public Result LogoutUser()
        {
            Task resultIdentity = _logoutRepository.LogoutUser();
            if (resultIdentity.IsCompletedSuccessfully)
                return Result.Ok();

            return Result.Fail("Logout falhou");
        }
    }
}
