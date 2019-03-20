using Database.Model;

namespace Database.Repositories
{
    public class CompanyRepository : BaseRepository<Company>
    {
        public CompanyRepository(MovieContext context)
            : base(context)
        {
        }
    }
}
