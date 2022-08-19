using System.ComponentModel.DataAnnotations;

namespace UserApi.Domain.Dtos.Request.Login
{
    public class LoginRequestDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
