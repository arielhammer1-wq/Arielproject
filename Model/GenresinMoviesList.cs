using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenresinMoviesList:List<GenresinMovies>
    {
        public GenresinMoviesList() { }
        public GenresinMoviesList(IEnumerable<GenresinMovies> list) : base(list) { }
        public GenresinMoviesList(IEnumerable<BaseEntity> list) : base(list.Cast<GenresinMovies>().ToList()) { }
    }
}
