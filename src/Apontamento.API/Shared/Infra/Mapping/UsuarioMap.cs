using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apontamento.App.Shared.Infra.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario.Domain.Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario.Domain.Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Nome).IsRequired().HasColumnType("varchar(150)");
            builder.Property(t => t.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(t => t.Senha).IsRequired().HasColumnType("varchar(100)");
            builder.Property(t => t.Ativo).IsRequired().HasColumnType("bit");

            builder.HasData(
                new Usuario.Domain.Usuario
                {
                    Nome = "Administrador",
                    Email = "admin@admin.com",
                    Senha = "admin",
                    Ativo = true,
                }
            );


        }
    }
}
