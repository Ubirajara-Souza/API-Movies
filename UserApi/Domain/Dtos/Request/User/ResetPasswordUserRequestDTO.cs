using System.ComponentModel.DataAnnotations;

namespace UserApi.Domain.Dtos.Request.User
{
    public class ResetPasswordUserRequestDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
