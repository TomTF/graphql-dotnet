using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Runtime { get; set; }

        public virtual ICollection<MovieCompany> ProductionCompanies { get; set; }
        public virtual ICollection<MovieGenre> Genres { get; set; }
    }
}
