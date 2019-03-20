using System;
using System.Collections.Generic;
using System.Text;

namespace DataImporter
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Runtime { get; set; }

        public string Genres { get; set; }
        public string Companies { get; set; }
    }
}
