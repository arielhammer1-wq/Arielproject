using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieScreeningDB : BaseDB
    {
        public MovieScreeningList SelectAll()
        {
            command.CommandText = "SELECT * FROM movieScreenings";
            MovieScreeningList list = new MovieScreeningList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieScreening s = entity as MovieScreening;
            s.Id = Convert.ToInt32(reader["id"]);
            s.HallId = new MovieHall
            {
                Id = Convert.ToInt32(reader["hallid"])
            };
            s.TimeOfScreening = Convert.ToDateTime(reader["TimeOfScreening"]);
            s.Movie = new Movie
            {
                Id = Convert.ToInt32(reader["MovieScreened"])
            };
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieScreening();
        }
    }
}
