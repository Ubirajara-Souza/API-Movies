using UserApi.Domain.Package;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Domain.Entities
{
    [Table("Usuario")]
    public class UserModel : EntityBase
    {
        [Required(ErrorMessage = "O campo UserName é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        public string Email { get; set; }

    }
}
