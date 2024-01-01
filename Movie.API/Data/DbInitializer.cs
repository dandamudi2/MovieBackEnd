
using Microsoft.EntityFrameworkCore;
using Movie.API.Models;

namespace Movie.API.Data
{
    public class DbInitializer
    {

       public static void InitDb(WebApplication app)
        {

            using var scope = app.Services.CreateScope();


            SeedData(scope.ServiceProvider.GetService<MovieDBContext>());
        }

        private static void SeedData(MovieDBContext context)
        {
            context.Database.Migrate();

            if (context.Platform.Any())
            {
                Console.WriteLine("Platform already have data!");
            }else
            {
                var platforms = new List<Platform>()
                {

                    new Platform
                    {
                        Id=Guid.NewGuid(),
                        PlatformName="Theatre"
                    },
                    new Platform
                    {
                        Id=Guid.NewGuid(),
                        PlatformName="Amazon Prime"
                    },
                    new Platform
                    {

                        Id=Guid.NewGuid(),
                        PlatformName = "Netflix"
                    },
                    new Platform
                    {
                        Id=Guid.NewGuid(),
                        PlatformName = "Hullu"
                    },
                     new Platform
                    {
                        Id=Guid.NewGuid(),
                        PlatformName = "Hullu"
                    },
                     new Platform
                    {
                        Id=Guid.NewGuid(),
                        PlatformName = "Disney Hotstar"
                    }

                };

                context.Platform.AddRange(platforms);

                context.SaveChanges();
            }

            if (context.Genres.Any())
            {
                Console.WriteLine("Platform already have data!");
            }else {
                var genres = new List<Genre>()
                {

                    new Genre
                    {
                        Id=Guid.NewGuid(),
                        GenreName="Drama"
                    },
                };

                context.Genres.AddRange(genres);

                context.SaveChanges();

            }
        }
    }
}
