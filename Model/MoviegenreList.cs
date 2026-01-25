using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieGenreList : List<MovieGenre>
    {
        public MovieGenreList() { }
        public MovieGenreList(IEnumerable<MovieGenre> list) : base(list) { }
        public MovieGenreList(IEnumerable<BaseEntity> list) : base(list.Cast<MovieGenre>().ToList()) { }
    }
}
