using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GenresInMoviesDB : BaseDB
    {
        public GenresinMoviesList SelectAll()
        {
            command.CommandText = "SELECT * FROM GenresinMovies";
            GenresinMoviesList list = new GenresinMoviesList(base.Select());
            return list;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            GenresinMovies a = entity as GenresinMovies;

            a.MG = MovieGenreDB.SelectById(int.Parse(reader["idGenre"].ToString()));

            a.M = MovieDB.SelectById(int.Parse(reader["idMovie"].ToString()));
            base.CreateModel(entity);
            return entity;
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity NewEntity()
        {
            return new GenresinMovies();
        }
    }
}

