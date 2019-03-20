using Core;
using GraphQL.Types;

namespace API.Model
{
    public class MovieQuery : ObjectGraphType
    {
        public MovieQuery(DataService dataService)
        {
            FieldAsync<ListGraphType<MovieType>>(
                "movies",
                arguments: new QueryArguments(
                   new QueryArgument<IntGraphType> { Name = "skip", Description = "skip n entries", DefaultValue = 0 },
                   new QueryArgument<IntGraphType> { Name = "take", Description = "take n entries", DefaultValue = 100 }
                ),
                resolve: async context =>
                    await dataService.FindMoviesAsync(
                        skip: context.GetArgument<int>("skip", defaultValue: 0),
                        take: context.GetArgument<int>("take", defaultValue: 100)));
        }
    }
}
