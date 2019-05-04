using System;
using Business.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.ConfiguracoesModelo
{
    public class PartidaDetalheConfiguracao : IEntityTypeConfiguration<PartidaDetalhe>
    {
        public void Configure(EntityTypeBuilder<PartidaDetalhe> builder)
        {
            builder.ToTable("PARTIDADETALHE");
            builder.HasKey(x => x.NumeroRound);

        //     builder.HasOne(x => x.Partida);

            builder.Property(x => x.NumeroRound)
                    .IsRequired()
                    .HasColumnName("NUMEROROUND");


            builder.Property(x => x.PartidaId)
                    .IsRequired()
                    .HasColumnName("PARTIDAID");


            builder.Property(x => x.EscolhaJogador)
                    .HasMaxLength(7)
                    .IsRequired()
                    .HasColumnName("ESCOLHAJOGADOR");

            builder.Property(x => x.EscolhaComputador)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("ESCOLHACOMPUTADOR");

            builder.Property(x => x.Resultado)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("RESULTADO");
        }
    }
}