using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class GenresInMoviesDB : BaseDB
    {
        public GenresinMoviesList SelectAll()
        {
            command.CommandText = "SELECT * FROM GenresinMovies";
            return new GenresinMoviesList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new GenresinMovies();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            GenresinMovies gm = entity as GenresinMovies;

            gm.Id = Convert.ToInt32(reader["Id"]);

            int mgId = Convert.ToInt32(reader["idMovie"]);
            int mId = Convert.ToInt32(reader["idGenre"]);

            gm.MG = MovieGenreDB.SelectById(mgId);
            gm.M = MovieDB.SelectById(mId);

            return gm;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            GenresinMovies gm = entity as GenresinMovies;

            cmd.CommandText =
                "INSERT INTO GenresinMovies (idGenre,idMovie) VALUES (@mg, @m)";

            cmd.Parameters.Add(new OleDbParameter("@mg", gm.MG.Id));
            cmd.Parameters.Add(new OleDbParameter("@m", gm.M.Id));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            GenresinMovies gm = entity as GenresinMovies;

            cmd.CommandText =
                "UPDATE GenresinMovies SET idGenre=@mg, idMovie=@m WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@mg", gm.MG.Id));
            cmd.Parameters.Add(new OleDbParameter("@m", gm.M.Id));
            cmd.Parameters.Add(new OleDbParameter("@id", gm.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            GenresinMovies gm = entity as GenresinMovies;

            cmd.CommandText = "DELETE FROM GenresinMovies WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", gm.Id));
        }

        public static GenresinMovies SelectById(int id)
        {
            GenresInMoviesDB db = new GenresInMoviesDB();
            GenresinMoviesList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }
    }
}
