using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ActorsInMovieDB : BaseDB
    {
        public ActorsInMovieList SelectAll()
        {
            command.CommandText = "SELECT * FROM ActorsinMovie";
            ActorsInMovieList list = new ActorsInMovieList(base.Select());
            return list;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ActorsInMovie a = entity as ActorsInMovie;
            if (a != null)
            {
                string sqlStr = $"DELETE FROM [ActorsinMovie] WHERE ID=@id";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", a.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ActorsInMovie a = entity as ActorsInMovie;
            if (a != null)
            {
                string sqlStr = $"Insert INTO [ActorsinMovie] (ArtistId,MovieId) " +
                    $"VALUES (@Artistid, @Movieid)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Artistid", a.M.Id));
                command.Parameters.Add(new OleDbParameter("@Movieid", a.A.Id));
            }
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ActorsInMovie a = entity as ActorsInMovie;
           
            a.A = ArtistDB.SelectById(int.Parse(reader["ArtistId"].ToString()));

            a.M = MovieDB.SelectById(int.Parse(reader["MovieId"].ToString()));
            base.CreateModel(entity);
            return entity;
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            ActorsInMovie a = entity as ActorsInMovie;
            if (a != null)
            {
                string sqlStr = "UPDATE ActorsinMovie SET ArtistId=@artistid,MovieId=@movieid WHERE ID=@id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@artistid", a.A.Id));
                cmd.Parameters.Add(new OleDbParameter("@movieid", a.M.Id));
                cmd.Parameters.Add(new OleDbParameter("@id", a.Id));
            }
        }

        protected override BaseEntity NewEntity()
        {
            return new ActorsInMovie();
        }
    }
}
