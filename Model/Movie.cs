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
        public AgeRating AgeRatingName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MovieGenre Genre { get; set; }
        public String PosterUrl { get; set; }
        public String TrailerUrl { get; set; }
    }
}
