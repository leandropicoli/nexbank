using Flunt.Notifications;
using Flunt.Validations;
using NexBank.Domain.Commands.Contracts;

namespace NexBank.Domain.Commands.AccountCommands
{
    public class CreateAccountCommand : Notifiable, ICommand
    {
        public CreateAccountCommand(string name, string document)
        {
            Name = name;
            Document = document;
        }

        public string Name { get; set; }
        public string Document { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 1, "Nome", "O Campo nome não pode ser vazio")
                    .HasMinLen(Document, 1, "Document", "O Campo documento não pode ser vazio")
            );
        }
    }
}