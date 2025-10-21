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
            MovieScreening m = entity as MovieScreening;
            m.HallId = Convert.ToInt32(reader["hallid"]);
            m.TimeOfScreening = Convert.ToDateTime(reader["TimeOfScreening"]);
            m.MovieScreened = reader["MovieScreened"].ToString();
            return base.CreateModel(entity);
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieScreening();
        }
    }

}
