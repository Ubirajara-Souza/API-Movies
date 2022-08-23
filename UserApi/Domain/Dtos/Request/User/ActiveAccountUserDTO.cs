using System.ComponentModel.DataAnnotations;

namespace UserApi.Domain.Dtos.Request.User
{
    public class ActiveAccountUserDTO
    {
        [Required(ErrorMessage = "O campo UserID é obrigatório")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "O campo ActivationCode é obrigatório")]
        public string ActivationCode { get; set; }
    }
}
