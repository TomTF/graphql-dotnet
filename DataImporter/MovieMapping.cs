using TinyCsvParser.Mapping;

namespace DataImporter
{
    public class MovieMapping : CsvMapping<Movie>
    {
        public MovieMapping()
        {
            MapProperty(3, m => m.Id);
            MapProperty(17, m => m.Title);
            MapProperty(16, m => m.Tagline);
            MapProperty(6, m => m.OriginalTitle);
            MapProperty(5, m => m.OriginalLanguage);
            MapProperty(7, m => m.Overview);
            MapProperty(11, m => m.ReleaseDate);
            MapProperty(9, m => m.Companies);
            MapProperty(1, m => m.Genres);
            MapProperty(13, m => m.Runtime);
        }
    }
}
