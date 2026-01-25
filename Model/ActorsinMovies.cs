using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ActorsInMovie : BaseEntity
    {
        public Artist A { get; set; }
        public Movie M { get; set; }
    }
}
