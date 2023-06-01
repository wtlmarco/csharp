using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

using CadastroDePacientes.API.Models;

namespace CadastroDePacientes.API.Data;

public interface IApplicationDbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Convenio> Convenios { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
