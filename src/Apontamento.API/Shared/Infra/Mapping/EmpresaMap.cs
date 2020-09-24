using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apontamento.App.Shared.Infra.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa.Domain.Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa.Domain.Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(t => t.Status).IsRequired().HasColumnType("bit");

        }
    }
}
