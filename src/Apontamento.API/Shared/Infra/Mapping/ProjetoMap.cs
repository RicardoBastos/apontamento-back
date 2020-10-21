using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apontamento.App.Shared.Infra.Mapping
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto.Domain.Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto.Domain.Projeto> builder)
        {

            builder.ToTable("Projeto");
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(t => t.EmpresaId).IsRequired().HasColumnType("bit");

            builder.Property(e => e.EmpresaId)
               .HasColumnName("EmpresaId")
               .HasColumnType("uniqueidentifier");

            builder.HasOne(e => e.Empresa)
                 .WithMany(e => e.Projetos)
                 .HasForeignKey(e => e.EmpresaId);

        }
    }
}
