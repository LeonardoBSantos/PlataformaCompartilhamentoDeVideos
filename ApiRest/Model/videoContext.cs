using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model
{
    public class videoContext : DbContext
    {
        //construtor da classe 
        public videoContext(DbContextOptions<videoContext> options) : base(options)
        {
        }

        //Registrando o model
        public DbSet<video> videoItems { get; set; }
        public DbSet<categoria> categoriaItems { get; set; }

        //Fluent API - configurando campos da tabela
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<video>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<video>().Property(p => p.Titulo).IsRequired();
            modelBuilder.Entity<video>().Property(p => p.Descricao).IsRequired();
            modelBuilder.Entity<video>().Property(p => p.Url).IsRequired();
            modelBuilder.Entity<video>()
                .HasOne<categoria>()
                .WithMany()
                .HasForeignKey(p => p.fk_categoriaId);

            modelBuilder.Entity<categoria>().HasKey(p => p.categoriaId);
            modelBuilder.Entity<categoria>().Property(p => p.nome).IsRequired();
            modelBuilder.Entity<categoria>().Property(p => p.cor).IsRequired();
        }
    }
}
