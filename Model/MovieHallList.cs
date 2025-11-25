using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieHallList : List<MovieHall>
    {
        public MovieHallList() { }
        public MovieHallList(IEnumerable<MovieHall> list) : base(list) { }
        public MovieHallList(IEnumerable<BaseEntity> list) : base(list.Cast<MovieHall>().ToList()) { }
    }
}
