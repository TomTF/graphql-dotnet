using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model
{
    public class MovieCompany : IEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CompanyId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Company Company { get; set; }
    }
}
