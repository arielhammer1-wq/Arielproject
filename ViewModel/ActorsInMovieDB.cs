using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class ActorsInMovieDB : BaseDB
    {
        public ActorsInMovieList SelectAll()
        {
            command.CommandText = "SELECT * FROM ActorsinMovie";
            return new ActorsInMovieList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new ActorsInMovie();
        }
        public static ActorsInMovie SelectById(int id)
        {
            ActorsInMovieDB db = new ActorsInMovieDB();
            ActorsInMovieList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ActorsInMovie a = entity as ActorsInMovie;

            // Load IDs
            a.Id = Convert.ToInt32(reader["Id"]);
            int artistId = Convert.ToInt32(reader["ArtistId"]);
            int movieId = Convert.ToInt32(reader["MovieId"]);

            // Load referenced objects
            a.A = ArtistDB.SelectById(artistId);
            a.M = MovieDB.SelectById(movieId);

            return a;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ActorsInMovie a = entity as ActorsInMovie;

            cmd.CommandText = @"INSERT INTO ActorsinMovie (ArtistId, MovieId)
                                VALUES (@artist, @movie)";

            cmd.Parameters.Add(new OleDbParameter("@artist", a.A.Id));
            cmd.Parameters.Add(new OleDbParameter("@movie", a.M.Id));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ActorsInMovie a = entity as ActorsInMovie;

            cmd.CommandText = @"UPDATE ActorsinMovie 
                                SET ArtistId=@artist, MovieId=@movie 
                                WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@artist", a.A.Id));
            cmd.Parameters.Add(new OleDbParameter("@movie", a.M.Id));
            cmd.Parameters.Add(new OleDbParameter("@id", a.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ActorsInMovie a = entity as ActorsInMovie;

            cmd.CommandText = "DELETE FROM ActorsinMovie WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", a.Id));
        }
    }
}