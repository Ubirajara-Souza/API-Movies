using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Domain.Dtos.Request.Address
{
    public class UpdateAddressDTO
    {
        [Required(ErrorMessage = "O campo Rua é obrigatório")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O campo Numero é obrigatório")]
        public int Number { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string State { get; set; }

        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string ZipCode { get; set; }
    }
}
