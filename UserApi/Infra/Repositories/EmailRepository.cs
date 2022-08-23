using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using UserApi.Domain.Entities;

namespace UserApi.Infra.Repositories
{
    public class EmailRepository
    {
        private IConfiguration _configuration;

        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SubmitEmail(string[] recipient, string theme, int userID, string token)
        {
            MessageModel messageModel = new MessageModel(recipient, theme, userID, token);
            MimeMessage messageEmail = CreateBodyEmail(messageModel);
            Submit(messageEmail);
        }

        public MimeMessage CreateBodyEmail(MessageModel messageModel)
        {
            MimeMessage messageEmail = new MimeMessage();
            messageEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            messageEmail.To.AddRange(messageModel.Recipient);
            messageEmail.Subject = messageModel.Theme;
            messageEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = messageModel.Content
            };
            return messageEmail;
        }

        public void Submit(MimeMessage messageEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(messageEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
