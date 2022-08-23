using MimeKit;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace UserApi.Domain.Entities
{

    [Table("Mensagem")]
    public class MessageModel
    {
        [Required(ErrorMessage = "O campo Recipient é obrigatório")]
        public List<MailboxAddress> Recipient { get; set; }

        [Required(ErrorMessage = "O campo Theme é obrigatório")]
        public string Theme { get; set; }

        [Required(ErrorMessage = "O campo Content é obrigatório")]
        public string Content { get; set; }

        public MessageModel(IEnumerable<string> recipient, string theme, int userID, string token)
        {
            Recipient = new List<MailboxAddress>();
            Recipient.AddRange(recipient.Select(r => new MailboxAddress(r)));
            Theme = theme;
            Content = $"http://localhost:6000/ativa?UserID={userID}&ActivationCode={token}";

        }
    }
}
