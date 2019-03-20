using System.Collections.Generic;

namespace Database.Model
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieCompany> Movies { get; set; }
    }
}