using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(MovieContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Genre>> FindGenresAsync(int id)
        {
            return await this.Context.MovieGenres
                .Where(g => g.MovieId == id)
                .Select(g => g.Genre)
                .ToListAsync();
        }
    }
}
