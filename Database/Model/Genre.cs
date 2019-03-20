using System.Collections.Generic;

namespace Database.Model
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieGenre> Movies { get; set; }
    }
}