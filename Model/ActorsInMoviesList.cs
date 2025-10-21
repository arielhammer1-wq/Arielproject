using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ActorsInMovieList : List<ActorsInMovie>
    {
        public ActorsInMovieList() { }
        public ActorsInMovieList(IEnumerable<ActorsInMovie> list) : base(list) { }
        public ActorsInMovieList(IEnumerable<BaseEntity> list) : base(list.Cast<ActorsInMovie>().ToList()) { }
    }

}
