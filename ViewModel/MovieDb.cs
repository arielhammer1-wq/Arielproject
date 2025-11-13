using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MoviesDB : BaseDB
    {
        public MovieList SelectAll()
        {
            command.CommandText = "SELECT * FROM Movies";
            MovieList list = new MovieList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Movie m = entity as Movie;
            m.Id = Convert.ToInt32(reader["Id"]);
            m.MovieName = reader["MovieName"].ToString();
            m.MovieLength = Convert.ToInt32(reader["MovieLength(min)"]);
            m.AgeRatingName = new AgeRating
            {
                Id = Convert.ToInt32(reader["AgeRating"])
            };
            m.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
            m.Genre = new MovieGenre
            {
                Id = Convert.ToInt32(reader["Genre"])
            };
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Movie();
        }
    }
}
