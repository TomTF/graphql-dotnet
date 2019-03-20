using System.Collections.Generic;
using Core;
using Core.Model;
using GraphQL.Types;

namespace API.Model
{
    public class MovieType : ObjectGraphType<Movie>
    {
        public MovieType(DataService dataService)
        {
            Field(x => x.Id);
            Field(x => x.Title).Description("the movies title");
            Field(x => x.Runtime).Description("runtime of the movie");
            Field(x => x.Overview).Description("a short description of the movie");
            Field(x => x.ReleaseDate).Description("date of the movies release");

            Field<ListGraphType<GenreType>, IEnumerable<Genre>>()
                .Name("genres")
                .Description("the genres of the movie")
                .ResolveAsync(context => dataService.FindGenresByMovieAsync(context.Source.Id));
        }
    }
}
