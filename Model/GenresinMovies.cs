using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenresinMovies : BaseEntity
    {
        public MovieGenre MG{ get; set; }
        public Movie M { get; set; }
    }
}
