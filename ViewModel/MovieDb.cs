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
        public static Movie SelectById(int id)
        {
            MovieDB db = new MovieDB();
            MovieList list = db.SelectAll();
            Movie g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Movie m = entity as Movie;
            m.Id = Convert.ToInt32(reader["Id"]);
            m.MovieName = reader["MovieName"].ToString();
            m.MovieLength = Convert.ToInt32(reader["MovieLength(min)"]);
            // הטיפוס הוא Agerating ולכן אני משתמש בselectbyid בשביל לבחור את המשתנה הנכון אחרי שעשיתי parse
            m.AgeRatingName = AgeRatingDB.SelectById( int.Parse(reader["AgeRating"].ToString()));           
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
