using System.ComponentModel.DataAnnotations;

namespace UserApi.Domain.Dtos.Request.User
{
    public class ConfirmResetUserRequestDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
