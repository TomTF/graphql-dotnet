using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TinyCsvParser;

namespace DataImporter
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var csvParserOptions = new CsvParserOptions(true, ',');
            var csvMapper = new MovieMapping();
            CsvParser<Movie> csvParser = new CsvParser<Movie>(csvParserOptions, csvMapper);

            var result = csvParser
                .ReadFromFile(@"tmdb_5000_movies.csv", Encoding.ASCII)
                .ToList();


            var movies = result.Where(r => r.IsValid).Select(r => r.Result).ToList();

            var genres = movies
                .SelectMany(m => JsonConvert.DeserializeObject<IEnumerable<Entity>>(m.Genres))
                .Distinct()
                .OrderBy(g => g.Id)
                .Select(c => new Database.Model.Genre
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            var companies = movies
                .SelectMany(m => JsonConvert.DeserializeObject<IEnumerable<Entity>>(m.Companies))
                .Distinct()
                .OrderBy(g => g.Id)
                .Select(c => new Database.Model.Company
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();


            using (var context = new Database.MovieContext())
            {

                await context.AddRangeAsync(genres);

                await context.Database.OpenConnectionAsync();
                await context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT dbo.Genres ON");
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT dbo.Genres OFF");

                await context.AddRangeAsync(companies);

                await context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT dbo.Companies ON");
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT dbo.Companies OFF");

                var allMovies = new List<Database.Model.Movie>();
                foreach (var m in movies)
                {
                    var movieCompanies = JsonConvert.DeserializeObject<IEnumerable<Entity>>(m.Companies)
                        .Where(c => c.Id != 0)
                        .Select(c => new Database.Model.MovieCompany
                        {
                            CompanyId = c.Id
                        })
                        .ToList();

                    var movieGenres = JsonConvert.DeserializeObject<IEnumerable<Entity>>(m.Genres)
                        .Where(g => g.Id != 0)
                        .Select(c => new Database.Model.MovieGenre
                        {
                            GenreId = c.Id,
                        })
                        .ToList();

                    var movie = new Database.Model.Movie
                    {
                        OriginalLanguage = m.OriginalLanguage,
                        OriginalTitle = m.OriginalTitle,
                        Overview = m.Overview,
                        ReleaseDate = m.ReleaseDate,
                        Runtime = TimeSpan.FromMinutes(m.Runtime),
                        Tagline = m.Tagline,
                        Title = m.Title,
                        ProductionCompanies = movieCompanies,
                        Genres = movieGenres
                    };

                    allMovies.Add(movie);
                }

                await context.AddRangeAsync(allMovies);
                await context.SaveChangesAsync();
                
            }

            Console.WriteLine();


        }
    }
}
