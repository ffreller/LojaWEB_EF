using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;
using LojaWEB_EF.Models;

namespace LojaWEB_EF.Contextos
{
    public class LojaContexto:DbContext
    {
        public LojaContexto(DbContextOptions<LojaContexto>options):base(options)
        {}

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Cliente>().ToTable("Cliente");
            modelbuilder.Entity<Produto>().ToTable("Produto");
            modelbuilder.Entity<Pedido>().ToTable("Pedido");
        }
        
    }
}