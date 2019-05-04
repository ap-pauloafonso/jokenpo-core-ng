using System;
using Business.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.ConfiguracoesModelo
{
    public class PartidaConfiguracao : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {

        
            builder.ToTable("PARTIDA");
            builder.HasKey(x => x.PartidaId);
            builder.HasOne(x => x.Usuario);
            builder.HasMany(X => X.detalhes);

            builder.Property(x => x.PartidaId)
            .ValueGeneratedOnAdd()
            .HasColumnName("PARTIDAID")
            .IsRequired();

            builder.Property(x => x.UsuarioId)
            .IsRequired()
            .HasColumnName("USERID");

            builder.Property(x => x.datahorainicio)
            .IsRequired()
            .HasColumnName("DATAHORAINICIO");

            builder.Property(x => x.datahorafim)
            .HasColumnName("DATAHORAFIM");

        }
    }
}