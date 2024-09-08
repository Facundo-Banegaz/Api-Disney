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


    }
}
