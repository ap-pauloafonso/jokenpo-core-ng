using System;
using Business.Modelos;
using Infra.Data.ConfiguracoesModelo;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class JokenpoContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PartidaConfiguracao());
            modelBuilder.ApplyConfiguration(new PartidaDetalheConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            base.OnModelCreating(modelBuilder);
        }


        public JokenpoContext(DbContextOptions<JokenpoContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<PartidaDetalhe> PartidaDetalhe { get; set; }


    }
}
