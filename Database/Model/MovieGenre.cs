using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model
{
    public class MovieGenre : IEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
