using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public TimeSpan Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
