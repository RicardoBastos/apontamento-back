using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Apontamento.App.Shared.Infra.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario.Application.Domain.Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario.Application.Domain.Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Nome).IsRequired().HasColumnType("varchar(150)");
            builder.Property(t => t.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(t => t.Senha).IsRequired().HasColumnType("varchar(100)");
            builder.Property(t => t.Status).IsRequired().HasColumnType("bit");

            var usuario = new Usuario.Application.Domain.Usuario();
            usuario.SetUsuario(Guid.NewGuid(), "Administrador", "admin@admin.com", "admin", true);

            builder.HasData(usuario);


        }
    }
}
