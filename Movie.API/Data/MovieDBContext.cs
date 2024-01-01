using Microsoft.EntityFrameworkCore;
using Movie.API.Models;

namespace Movie.API.Data
{
    public class MovieDBContext: DbContext
    {

        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            :base(options)
        {
            
        }


        public DbSet<Movies> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }


        public DbSet<Platform> Platform { get; set; }


        public DbSet<ReviewAndRating> ReviewAndRating { get; set; }
    }
}
