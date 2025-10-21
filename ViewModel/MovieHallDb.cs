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
            command.CommandText = "SELECT * FROM MovieHalls";
            MovieHallList list = new MovieHallList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieHall m = entity as MovieHall;
            m.HallName = reader["HallName"].ToString();
            m.AmountOfSeats = Convert.ToInt32(reader["AmountOfSeats"]);
            m.TheaterId = Convert.ToInt32(reader["theaterid"]);
            return base.CreateModel(entity);
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieHall();
        }
    }

}
