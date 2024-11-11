using kpZleceniaWeb.Shared.Common.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace kpZleceniaWeb.Shared.User.Command
{
    public class AddEditUserCommand : IRequest<InfoDto>
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Pole 'E-mail' jest wymagane.")]
        [EmailAddress(ErrorMessage = "Pole 'E-mail' musi być prawidłowym adresem e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole 'Imię' jest wymagane.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pole 'Nazwisko' jest wymagane.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pole 'Hasło' jest wymagane.")]
        //[StringLength(100, ErrorMessage = "Hasło musi mieć co najmniej {2} znaków i nie więcej niż {1} znaków długości.", MinimumLength = 8)]
        public string Password { get; set; }

        [Compare(nameof(Password),
            ErrorMessage = "Hasło i Potwierdzone hasło są różne.")]
        public string ConfirmPassword { get; set; }


        public IDictionary<string, bool> Roles { get; set; }

        public bool PCH { get; set; }
    }
}
