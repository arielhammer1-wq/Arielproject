using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

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

        protected override BaseEntity NewEntity()
        {
            return new Movie();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Movie m = entity as Movie;

            m.Id = Convert.ToInt32(reader["Id"]);
            m.MovieName = reader["MovieName"].ToString();
            m.MovieLength = Convert.ToInt32(reader["MovieLength"]);

            // Load AgeRating object using FK number
            m.AgeRatingName = AgeRatingDB.SelectById(Convert.ToInt32(reader["AgeRating"]));

            // Release date
            m.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);

            // Load main Genre object using FK number
            m.Genre = MovieGenreDB.SelectById(Convert.ToInt32(reader["Genre"]));

            return m;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Movie m = entity as Movie;
            if (m != null)
            {
                string sqlStr =
                    "INSERT INTO Movie (MovieName, MovieLength, AgeRating, ReleaseDate, Genre) " +
                    "VALUES (@name, @length, @age, @date, @genre)";

                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@name", m.MovieName));
                cmd.Parameters.Add(new OleDbParameter("@length", m.MovieLength));
                cmd.Parameters.Add(new OleDbParameter("@age", m.AgeRatingName.Id));
                cmd.Parameters.Add(new OleDbParameter("@date", m.ReleaseDate));
                cmd.Parameters.Add(new OleDbParameter("@genre", m.Genre.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Movie m = entity as Movie;
            if (m != null)
            {
                string sqlStr =
                    "UPDATE Movie SET MovieName=@name, MovieLength=@length, AgeRating=@age, " +
                    "ReleaseDate=@date, Genre=@genre WHERE ID=@id";

                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@name", m.MovieName));
                cmd.Parameters.Add(new OleDbParameter("@length", m.MovieLength));
                cmd.Parameters.Add(new OleDbParameter("@age", m.AgeRatingName.Id));
                cmd.Parameters.Add(new OleDbParameter("@date", m.ReleaseDate));
                cmd.Parameters.Add(new OleDbParameter("@genre", m.Genre.Id));
                cmd.Parameters.Add(new OleDbParameter("@id", m.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Movie m = entity as Movie;

            string sqlStr = "DELETE FROM Movie WHERE ID=@id";
            cmd.CommandText = sqlStr;

            cmd.Parameters.Add(new OleDbParameter("@id", m.Id));
        }

        public static Movie SelectById(int id)
        {
            MovieDB db = new MovieDB();
            MovieList list = db.SelectAll();
            return list.Find(m => m.Id == id);
        }
    }
}