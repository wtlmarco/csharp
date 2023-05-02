using System.ComponentModel.DataAnnotations;

namespace App.ViewModels;

public class RedefinirSenhaViewModel
{
    [Required]
    public string Token { get; set; }

    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Email { get; set; }

    [Display(Name = "Criação da Nova Senha")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [MaxLength(16, ErrorMessage = "O tamanho máximo do campo {0} é de {1}.")]
    [MinLength(6, ErrorMessage = "O tamanho mínimo do campo {0} é de {1}.")]
    public string NovaSenha { get; set; }

    [Display(Name = "Confirmação da Nova Senha")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [MaxLength(16, ErrorMessage = "O tamanho máximo do campo {0} é de {1}.")]
    [MinLength(6, ErrorMessage = "O tamanho mínimo do campo {0} é de {1}.")]
    [Compare(nameof(NovaSenha), ErrorMessage = "A confirmação da senha não confere.")]
    public string ConfNovaSenha { get; set; }
    

}