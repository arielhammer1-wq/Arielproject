using Model;
using System;
using System.Collections.Generic;
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

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ActorsInMovie a = entity as ActorsInMovie;
            a.ArtistId = Convert.ToInt32(reader["ArtistId"]);
            a.MovieId = Convert.ToInt32(reader["MovieId"]);
            return base.CreateModel(entity);
        }

        protected override BaseEntity NewEntity()
        {
            return new ActorsInMovie();
        }
    }

}
