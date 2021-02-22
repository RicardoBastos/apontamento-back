using Apontamento.Shared.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Apontamento.Shared.Infra
{

    public class ApontamentoContext : DbContext
    {
        public DbSet<Empresa.Domain.Entities.Empresa> Empresa { get; set; }
        public DbSet<Usuario.Domain.Usuario> Usuario { get; set; }
        public DbSet<Projeto.Domain.Projeto> Projeto{ get; set; }



        public ApontamentoContext(DbContextOptions<ApontamentoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProjetoMap());

        }
    }
}
