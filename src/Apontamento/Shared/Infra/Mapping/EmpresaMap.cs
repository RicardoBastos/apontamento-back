using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apontamento.Shared.Infra.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa.Domain.Entities.Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa.Domain.Entities.Empresa> builder)
        {

            builder.ToTable("Empresa");
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(t => t.Status).IsRequired().HasColumnType("bit");

            builder.HasMany(c => c.Projetos).WithOne();

        }
    }
}
