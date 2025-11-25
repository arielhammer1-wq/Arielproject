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
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        protected override BaseEntity NewEntity()
        {
            return new ActorsInMovie();
        }
    }
}
