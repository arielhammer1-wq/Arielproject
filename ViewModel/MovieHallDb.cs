using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieHallDB : BaseDB
    {
        public MovieHallList SelectAll()
        {
            command.CommandText = "SELECT * FROM movieHalls";
            MovieHallList list = new MovieHallList(base.Select());
            return list;
        }
        public static MovieHall SelectById(int id)
        {
            MovieHallDB db = new MovieHallDB();
            MovieHallList list = db.SelectAll();
            MovieHall g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieHall h = entity as MovieHall;
            h.Id = Convert.ToInt32(reader["id"]);
            h.HallName = reader["HallName"].ToString();
            h.AmountOfSeats = Convert.ToInt32(reader["AmountOfSeats"]);
            h.Theater = new Theater
            {
                Id = Convert.ToInt32(reader["theaterid"])
            };
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieHall();
        }
    }
}