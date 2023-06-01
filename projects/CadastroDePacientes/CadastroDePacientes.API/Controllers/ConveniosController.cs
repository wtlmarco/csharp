using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentValidation;

using CadastroDePacientes.API.Data;
using CadastroDePacientes.API.Log;
using CadastroDePacientes.API.Models;
using FluentValidation.Results;
using CadastroDePacientes.API.Extensions;

namespace CadastroDePacientes.API.Controllers;

[ApiController]
[Route("api/convenios")]
public class ConveniosController : ControllerBase
{
    private readonly IApplicationDbContext _db;

    private readonly ILoggerManager _logger;

    private readonly IValidator<Convenio> _validator;

    public ConveniosController(IApplicationDbContext db,
        ILoggerManager logger,
        IValidator<Convenio> validator)
    {
        _db = db;
        _logger = logger;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        _logger.LogInfo("Buscando todos os Convenios ...");

        var convenios = await _db.Convenios.ToListAsync();

        _logger.LogInfo($"Foram retornados {convenios.Count} Convenios com sucesso");

        return Ok(convenios);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("FiltrarPorId")]
    public async Task<IActionResult> FiltrarPorId([FromRoute] Guid id)
    {
        _logger.LogInfo($"Buscando Convenio {id} ...");

        var convenio = await _db.Convenios.FirstOrDefaultAsync(p => p.ID == id);
        if (convenio != null)
        {
            _logger.LogInfo($"Convenio {id} retornado com sucesso");

            return Ok(convenio);
        }

        _logger.LogInfo($"Convenio {id} não encontrado");

        return NotFound("Convenio não encontrado");
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] Convenio convenio)
    {
        ValidationResult validacao = await _validator.ValidateAsync(convenio);
        if (!validacao.IsValid)
        {
            validacao.AddToModelState(ModelState);

            return BadRequest(ModelState);
        }

        convenio.ID = Guid.NewGuid();

        _logger.LogInfo($"Adicionando Convenio {convenio.ID} ...");

        await _db.Convenios.AddAsync(convenio);
        await _db.SaveChangesAsync();

        _logger.LogInfo($"Convenio {convenio.ID} adicionado com sucesso");

        return CreatedAtAction(nameof(FiltrarPorId), new { id = convenio.ID }, convenio);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] Convenio convenio)
    {
        var validacao = await _validator.ValidateAsync(convenio);
        if (!validacao.IsValid)
        {
            validacao.AddToModelState(ModelState);

            return BadRequest(ModelState);
        }

        var convenioAtual = await _db.Convenios.FirstOrDefaultAsync(c => c.ID == id);

        if (convenioAtual != null)
        {
            _logger.LogInfo($"Alterando Paciente {id} ...");

            convenioAtual.Nome = convenio.Nome;

            await _db.SaveChangesAsync();

            _logger.LogInfo($"Convenio {convenioAtual.ID} alterado com sucesso");

            return Ok(convenioAtual);
        }

        _logger.LogInfo($"Convenio {id} não encontrado");

        return NotFound("Convenio não encontrado");
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Remover([FromRoute] Guid id)
    {
        var convenio = await _db.Convenios.FirstOrDefaultAsync(c => c.ID == id);

        if (convenio != null)
        {
            _logger.LogInfo($"Removendo Convenio {id} ...");

            _db.Convenios.Remove(convenio);
            await _db.SaveChangesAsync();

            _logger.LogInfo($"Convenio {convenio.ID} removido com sucesso");

            return Ok(convenio);
        }

        _logger.LogInfo($"Convenio {id} não encontrado");

        return NotFound("Convenio não encontrado");
    }
}
