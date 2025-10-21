using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieDB : BaseDB
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
            m.MovieName = reader["MovieName"].ToString();
            m.MovieLength = Convert.ToInt32(reader["MovieLength(min)"]);
            m.AgeRating = reader["AgeRating"].ToString();
            m.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
            m.GenreId = Convert.ToInt32(reader["GenreID"]);
            return base.CreateModel(entity);
        }

        protected override BaseEntity NewEntity()
        {
            return new Movie();
        }
    }

}
