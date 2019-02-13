using System.ComponentModel.DataAnnotations;

namespace Adolfo.AspNetIdentity.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelomenos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da senha não coincidem.")]
        public string ConfirmPassword { get; set; }

        public string returnUrl { get; set; } = null;
    }
}
