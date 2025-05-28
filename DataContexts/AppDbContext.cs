using ApiLocadora.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLocadora.DataContexts
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Estudio> Estudios { get; set; }

        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()
                .HasOne(e => e.Estudio)
                .WithMany(e => e.Filmes)
                .HasForeignKey(e => e.EstudioId)
                .IsRequired(true);
        }

    }
}
