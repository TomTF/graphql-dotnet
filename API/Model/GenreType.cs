using Core.Model;
using GraphQL.Types;

namespace API.Model
{
    public class GenreType : ObjectGraphType<Genre>
    {
        public GenreType()
        {
            Field(g => g.Id);
            Field(g => g.Name);
        }
    }
}
