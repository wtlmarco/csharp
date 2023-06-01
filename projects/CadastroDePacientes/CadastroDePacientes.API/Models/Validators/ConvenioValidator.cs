using FluentValidation;
using FluentValidation.Validators;

namespace CadastroDePacientes.API.Models.Validators;

public class ConvenioValidator : AbstractValidator<Convenio>
{
    public ConvenioValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().MaximumLength(150);
    }
}
