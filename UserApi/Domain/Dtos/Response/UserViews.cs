using UserApi.Domain.Package;

namespace UserApi.Domain.Dtos.Response
{
    public class UserViews : EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}

