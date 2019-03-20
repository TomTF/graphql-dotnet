using GraphQL;
using GraphQL.Types;

namespace API.Model
{
    public class MovieSchema : Schema
    {
        public MovieSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            this.Query = resolver.Resolve<MovieQuery>();
        }
    }
}
