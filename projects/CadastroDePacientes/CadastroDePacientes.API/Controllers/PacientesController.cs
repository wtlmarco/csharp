using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using CadastroDePacientes.API.Models;
using CadastroDePacientes.API.Data;
using CadastroDePacientes.API.Log;
using CadastroDePacientes.API.Extensions;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace CadastroDePacientes.API.Controllers;

[ApiController]
[Route("api/pacientes")]
public class PacientesController : ControllerBase
{
    private readonly IApplicationDbContext _db;

    private readonly ILoggerManager _logger;

    private readonly IValidator<Paciente> _validator;

    public PacientesController(IApplicationDbContext db, 
        ILoggerManager logger, 
        IValidator<Paciente> validator)
    {
        _db = db;
        _logger = logger;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        _logger.LogInfo("Buscando todos os Pacientes ...");

        var pacientes = await _db.Pacientes.Include(c => c.Convenio).ToListAsync();

        _logger.LogInfo($"Foram retornados {pacientes.Count} Pacientes com sucesso");

        return Ok(pacientes);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("FiltrarPorId")]
    public async Task<IActionResult> FiltrarPorId([FromRoute] Guid id)
    {
        _logger.LogInfo($"Buscando Paciente {id} ...");

        var paciente = await _db.Pacientes.Include(c => c.Convenio).FirstOrDefaultAsync(p => p.ID == id);
        if(paciente != null)
        {
            _logger.LogInfo($"Paciente {id} retornado com sucesso");

            return Ok(paciente);
        }

        _logger.LogInfo($"Paciente {id} não encontrado");

        return NotFound("Paciente não encontrado");
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] Paciente paciente)
    {
        var validacao = await _validator.ValidateAsync(paciente);
        if(!validacao.IsValid)
        {
            validacao.AddToModelState(ModelState);

            return BadRequest(ModelState);
        }

        var cpfDuplicado = await _db.Pacientes.Where(p => p.CPF == paciente.CPF).FirstOrDefaultAsync();
        if(cpfDuplicado != null)
        {
            ModelState.AddModelError("Cpf", "Já existe um Paciente registrado com esse Cpf");
            return BadRequest(ModelState);
        }

        paciente.ID = Guid.NewGuid();

        _logger.LogInfo($"Adicionando Paciente {paciente.ID} ...");

        TratarDadosVazioParaNulo(paciente);
        if (paciente.ConvenioID == null)
            paciente.Convenio = null;

        await _db.Pacientes.AddAsync(paciente);
        await _db.SaveChangesAsync();

        _logger.LogInfo($"Paciente {paciente.ID} adicionado com sucesso");

        return CreatedAtAction(nameof(FiltrarPorId), new { id = paciente.ID }, paciente);
    }

    private void TratarDadosVazioParaNulo(object model)
    {
        if (model == null) return;

        var propriedades = model.GetType().GetProperties();

        foreach (var prop in propriedades)
        {
            if (prop.PropertyType == typeof(string) && 
                prop.GetValue(model).ToString() == "")
                    prop.SetValue(model, null);
            else if (prop.PropertyType == typeof(Guid) &&
                prop.GetValue(model).ToString() == "00000000-0000-0000-0000-000000000000")
                 prop.SetValue(model, null);
            else if (prop.PropertyType == typeof(Guid?) &&
                prop.GetValue(model).ToString() == "00000000-0000-0000-0000-000000000000")
                    prop.SetValue(model, null);
        }
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] Paciente paciente)
    {
        var validacao = await _validator.ValidateAsync(paciente);
        if (!validacao.IsValid)
        {
            validacao.AddToModelState(ModelState);

            return BadRequest(ModelState);
        }
        
        var pacienteAtual = await _db.Pacientes.FirstOrDefaultAsync(p => p.ID == id);

        if (pacienteAtual != null)
        {
            _logger.LogInfo($"Alterando Paciente {id} ...");

            pacienteAtual.Nome = paciente.Nome;
            pacienteAtual.Sobrenome = paciente.Sobrenome;
            pacienteAtual.DataDeNascimento = paciente.DataDeNascimento;
            pacienteAtual.Genero = paciente.Genero;
            pacienteAtual.CPF = paciente.CPF;
            pacienteAtual.RG = paciente.RG;
            pacienteAtual.UFDoRG = paciente.UFDoRG;
            pacienteAtual.Email = paciente.Email;
            pacienteAtual.Celular = paciente.Celular;
            pacienteAtual.TelefoneFixo = paciente.TelefoneFixo;
            pacienteAtual.ConvenioID = paciente.ConvenioID.ToString() == "00000000-0000-0000-0000-000000000000" ? null : paciente.ConvenioID;
            pacienteAtual.CarteirinhaDoConvenio = paciente.CarteirinhaDoConvenio;
            pacienteAtual.ValidadeDaCarteirinha = paciente.ValidadeDaCarteirinha;

            await _db.SaveChangesAsync();

            _logger.LogInfo($"Paciente {paciente.ID} alterado com sucesso");

            var pacienteAtualizado = await _db.Pacientes
                .Include(c => c.Convenio)
                .FirstOrDefaultAsync(p => p.ID == paciente.ID);

            return Ok(pacienteAtualizado);
        }

        _logger.LogInfo($"Paciente {id} não encontrado");

        return NotFound("Paciente não encontrado");
    }
}
