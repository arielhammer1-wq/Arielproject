using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ActorsInMovie : BaseEntity
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
