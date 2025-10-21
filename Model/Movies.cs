using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movie : BaseEntity
    {
        public string MovieName { get; set; }
        public int MovieLength { get; set; }
        public string AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }
        public MovieGenre Genre { get; set; }

        public MovieScreeningList MovieScreenings { get; set; } = new MovieScreeningList();
        public ActorsInMovieList ActorsInMovies { get; set; } = new ActorsInMovieList();
    }
}
