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
        public static MovieScreening SelectById(int id)
        {
            MovieScreeningDB db = new MovieScreeningDB();
            MovieScreeningList list = db.SelectAll();
            MovieScreening g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieScreening s = entity as MovieScreening;
            s.Id = Convert.ToInt32(reader["id"]);
            s.HallId = MovieHallDB.SelectById(int.Parse(reader["hallid"].ToString()));


            s.TimeOfScreening = Convert.ToDateTime(reader["TimeOfScreening"]);
            s.Movie =MovieDB.SelectById(int.Parse(reader["MovieScreened"].ToString()));
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieScreening();
        }
    }
}
