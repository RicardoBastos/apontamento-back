using Apontamento.App.Shared.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Apontamento.App.Shared.Infra
{

    public class ApontamentoContext : DbContext
    {
        public DbSet<Empresa.Application.Domain.Empresa> Empresa { get; set; }
        public DbSet<Usuario.Application.Domain.Usuario> Usuario { get; set; }


        public ApontamentoContext(DbContextOptions<ApontamentoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
