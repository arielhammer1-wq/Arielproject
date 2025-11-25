using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieDB : BaseDB
    {
        public MovieList SelectAll()
        {
            command.CommandText = "SELECT * FROM Movie";
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
            m.MovieLength = Convert.ToInt32(reader["MovieLength"]);
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

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Movie m = entity as Movie;
            if (m != null)
            {
                string sqlStr = "UPDATE Movie SET MovieName=@mName,MovieLength=@mLength,AgeRating " +
                    "=@mAgeRating,ReleaseDate=@mRealeaseDate,Genre=@mGenre WHERE ID=@id";
                cmd.CommandText = sqlStr;

                int ageRatingId = m.AgeRatingName.Id;
                int genreId = m.Genre.Id;

                cmd.Parameters.Add(new OleDbParameter("@mName", m.MovieName));
                cmd.Parameters.Add(new OleDbParameter("@mLength", m.MovieLength));
                cmd.Parameters.Add(new OleDbParameter("@mAgeRating", ageRatingId));
                cmd.Parameters.Add(new OleDbParameter("@mReleaseDate", m.ReleaseDate));
                cmd.Parameters.Add(new OleDbParameter("@mGenre", genreId));
                cmd.Parameters.Add(new OleDbParameter("@id", m.Id));
            }
        }
    }
}
