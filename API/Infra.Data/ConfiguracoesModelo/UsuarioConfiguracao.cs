using System;
using Business.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.ConfiguracoesModelo
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            {
                builder.ToTable("USUARIO");
                builder.HasKey(x => x.UsuarioId);
                builder.HasIndex(x => x.email).IsUnique();

                builder.Property(x => x.UsuarioId)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("USERID");

                builder.HasMany(x=>x.partidas)
                .WithOne(a=>a.Usuario)
                .HasForeignKey(a=>a.UsuarioId);

                builder.Property(x => x.email)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("EMAIL");




                builder.Property(x => x.senha)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("SENHA");

                builder.Property(x => x.datahoracriacao)
                .IsRequired()
                .HasColumnName("DATAHORACRIACAO");

                builder.Property(x => x.datahoraconfirmacao)
                .HasColumnName("DATAHORACONFIRMACAO");

            }
        }
    }
}