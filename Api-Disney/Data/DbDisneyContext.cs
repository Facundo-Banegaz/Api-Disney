using Api_Disney.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Disney.Data
{
    public class DbDisneyContext:DbContext
    {

        public DbDisneyContext (DbContextOptions<DbDisneyContext> options):base(options)
        {

        }


        public DbSet<Movie> MovieOrSeries { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Genre> Genres { get; set; }

       public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación uno a muchos entre Movie y Genre
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genero)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GeneroId)
                .OnDelete(DeleteBehavior.Restrict); // O el comportamiento de eliminación que desees

            // Configuración de la relación muchos a muchos entre Movie y Character
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity(j => j.ToTable("CharacterMovieOrSeries")); // Nombre de la tabla de unión
        }
    }
}
