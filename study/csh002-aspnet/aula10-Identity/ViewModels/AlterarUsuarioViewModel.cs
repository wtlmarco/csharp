using System.ComponentModel.DataAnnotations;

namespace App.ViewModels;

public class AlterarUsuarioViewModel
{
    [Display(Name = "Nome Completo")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string NomeCompleto { get; set; }

    [Display(Name = "Data de Nascimento")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
 
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(11, ErrorMessage = "O campo {0} deve ter {1} dígitos.")]
    public string Telefone { get; set; }

    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Email { get; set; }
}