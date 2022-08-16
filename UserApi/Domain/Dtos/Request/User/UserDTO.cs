using System.ComponentModel.DataAnnotations;

namespace UserApi.Domain.Dtos.Request.User
{
    public class UserDTO
    {
        [Required(ErrorMessage = "O campo UserName é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo RePassword é obrigatório")]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
