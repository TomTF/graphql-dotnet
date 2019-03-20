using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Model;
using Database.Repositories;

namespace Core
{
    public class DataService
    {
        private readonly MovieRepository movieRepos;

        public DataService(MovieRepository movieRepos)
        {
            this.movieRepos = movieRepos;
        }

        public async Task<IEnumerable<Movie>> FindMoviesAsync(int skip = 0, int take = 100)
        {
            var movies = await this.movieRepos.FindAllAsync(skip, take);
            return movies.Select(m => new Movie
            {
                Id = m.Id,
                Overview = m.Overview,
                ReleaseDate = m.ReleaseDate,
                Runtime = m.Runtime,
                Title = m.Title,
            });
        }

        public async Task<IEnumerable<Genre>> FindGenresByMovieAsync(int id)
        {
            var genres = await this.movieRepos.FindGenresAsync(id);
            return genres.Select(g => new Genre
            {
                Id = g.Id,
                Name = g.Name,
            });
        }
    }
}
