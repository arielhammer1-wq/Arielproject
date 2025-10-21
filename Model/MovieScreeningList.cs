using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieScreeningList : List<MovieScreening>
    {
        public MovieScreeningList() { }
        public MovieScreeningList(IEnumerable<MovieScreening> list) : base(list) { }
        public MovieScreeningList(IEnumerable<BaseEntity> list) : base(list.Cast<MovieScreening>().ToList()) { }
    }
}
