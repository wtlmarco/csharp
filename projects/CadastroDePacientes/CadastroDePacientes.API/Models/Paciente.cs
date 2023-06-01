using System;

using CadastroDePacientes.API.Models.Validators;

namespace CadastroDePacientes.API.Models;

public class Paciente
{
    public Guid ID { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public string Genero { get; set; }
    public string? CPF { get; set; }
    public string RG { get; set; }
    public string UFDoRG { get; set; }
    public string Email { get; set; }
    public string? Celular { get; set; }
    public string? TelefoneFixo { get; set; }
    public Guid? ConvenioID { get; set; }
    public Convenio Convenio { get; set; }
    public string? CarteirinhaDoConvenio { get; set; }
    public DateTime? ValidadeDaCarteirinha { get; set; }
}
