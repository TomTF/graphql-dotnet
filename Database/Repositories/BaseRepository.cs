using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class BaseRepository<T> where T : class, IEntity
    {
        public MovieContext Context { get; }

        public BaseRepository(MovieContext context)
        {
            Context = context;
        }

        public Task<T> FindByIdAsync(int id)
        {
            return this.Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindByIdsAsync(IEnumerable<int> ids)
        {
            return await this.Context.Set<T>()
                .AsNoTracking()
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(int skip, int take)
        {
            return await this.Context.Set<T>()
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}