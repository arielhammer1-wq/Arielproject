using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieList : List<Movie>
    {
        public MovieList() { }
        public MovieList(IEnumerable<Movie> list) : base(list) { }
        public MovieList(IEnumerable<BaseEntity> list) : base(list.Cast<Movie>().ToList()) { }
    }
}
