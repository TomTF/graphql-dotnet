using Database.Model;

namespace Database.Repositories
{
    public class GenreRepository : BaseRepository<Genre>
    {
        public GenreRepository(MovieContext context)
            : base(context)
        {
        }
    }
}
