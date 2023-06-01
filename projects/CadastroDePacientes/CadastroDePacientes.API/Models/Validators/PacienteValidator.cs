using FluentValidation;
using Microsoft.IdentityModel.Tokens;

using CadastroDePacientes.API.Models.Validators.Helpers;
using CadastroDePacientes.API.Extensions;

namespace CadastroDePacientes.API.Models.Validators;

public class PacienteValidator : AbstractValidator<Paciente>
{
    public PacienteValidator()
    {
        RuleFor(p => p.Nome).NotEmpty().MaximumLength(50);
                     
        RuleFor(p => p.Sobrenome).NotEmpty().MaximumLength(100);
                     
        RuleFor(p => p.DataDeNascimento).NotEmpty().WithName("Data de Nascimento");
                     
        RuleFor(p => p.Genero).NotEmpty().MaximumLength(50).WithName("Gênero");

        RuleFor(p => p.CPF)
            .Must(cpf => ValidatorsHelpers.IsValidCpf(cpf))
            .WithMessage("O CPF informado é inválido");
                     
        RuleFor(p => p.RG).NotEmpty().MaximumLength(20);

        RuleFor(p => p.UFDoRG).NotEmpty().Length(2).WithName("Estado do RG");
                     
        RuleFor(p => p.Email).NotEmpty().MaximumLength(256).EmailAddress();

        RuleFor(p => p.Celular).MaximumLength(15)
            .Must(UmTelefoneInformado)
            .WithMessage("O número do Celular ou Telefone deve ser informado");
                     
        RuleFor(p => p.TelefoneFixo).MaximumLength(15)
            .Must(UmTelefoneInformado)
            .WithMessage("O número do Celular ou Telefone deve ser informado");
            
        RuleFor(p => p.CarteirinhaDoConvenio).MaximumLength(50).WithName("Carteirinha do Convênio");
    }

    private bool UmTelefoneInformado(Paciente paciente, string valor)
    {
        if (paciente.TelefoneFixo.IsNullOrEmpty() 
            && paciente.Celular.IsNullOrEmpty() 
            && valor.IsNullOrEmpty())
        {
            return false;
        }

        return true;
    }
}
