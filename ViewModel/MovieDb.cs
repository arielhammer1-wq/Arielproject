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
            return new MovieList(base.Select());
        }

        protected override BaseEntity NewEntity() => new Movie();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Movie m = entity as Movie;

            m.Id = Convert.ToInt32(reader["Id"]);
            m.MovieName = reader["MovieName"].ToString();
            m.MovieLength = Convert.ToInt32(reader["MovieLength"]);
            m.AgeRatingName = AgeRatingDB.SelectById(Convert.ToInt32(reader["AgeRating"]));   // ID
            m.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
            m.Genre = MovieGenreDB.SelectById(Convert.ToInt32(reader["Genre"]));           // ID
            m.PosterUrl = reader["PosterUrl"].ToString();
            m.TrailerUrl= reader["TrailerUrl"].ToString();

            return m;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Movie m = entity as Movie;

            cmd.CommandText =
                @"INSERT INTO Movie (MovieName, MovieLength, AgeRating, ReleaseDate, Genre, PosterUrl,TrailerUrl)
                  VALUES (@name, @length, @age, @date, @genre, @PosterUrl,@TrailerUrl)";

            cmd.Parameters.Add(new OleDbParameter("@name", m.MovieName));
            cmd.Parameters.Add(new OleDbParameter("@length", m.MovieLength));
            cmd.Parameters.Add(new OleDbParameter("@age", m.AgeRatingName.Id));
            cmd.Parameters.Add(new OleDbParameter("@date", m.ReleaseDate));
            cmd.Parameters.Add(new OleDbParameter("@genre", m.Genre.Id));
            cmd.Parameters.Add(new OleDbParameter("@PosterUrl", m.PosterUrl));
            cmd.Parameters.Add(new OleDbParameter("@TrailerUrl", m.TrailerUrl));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Movie m = entity as Movie;

            cmd.CommandText =
                @"UPDATE Movie 
                  SET MovieName=@name, MovieLength=@length, AgeRating=@age, 
                      ReleaseDate=@date, Genre=@genre ,PosterUrl=@PosterUrl,TrailerUrl=@TrailerUrl
                  WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@name", m.MovieName));
            cmd.Parameters.Add(new OleDbParameter("@length", m.MovieLength));
            cmd.Parameters.Add(new OleDbParameter("@age",m.AgeRatingName.Id));
            cmd.Parameters.Add(new OleDbParameter("@date", m.ReleaseDate));
            cmd.Parameters.Add(new OleDbParameter("@genre", m.Genre.Id));
            cmd.Parameters.Add(new OleDbParameter("@id", m.Id));
            cmd.Parameters.Add(new OleDbParameter("@PosterUrl", m.PosterUrl));
            cmd.Parameters.Add(new OleDbParameter("@TrailerUrl", m.TrailerUrl));

        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Movie m = entity as Movie;
            cmd.CommandText = "DELETE FROM Movie WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", m.Id));
        }
        public static Movie SelectById(int id)
        {
            MovieDB db = new MovieDB();
            MovieList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }
    }
}
