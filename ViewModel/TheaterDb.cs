using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TheaterDB : BaseDB
    {
        public TheaterList SelectAll()
        {
            command.CommandText = "SELECT * FROM Theaters";
            TheaterList list = new TheaterList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Theater t = entity as Theater;
            t.NameOfTheater = reader["NameOfTheater"].ToString();
            t.Address = reader["Address"].ToString();
            t.StreetNumber = Convert.ToInt32(reader["StreetNumber"]);
            return base.CreateModel(entity);
        }

        protected override BaseEntity NewEntity()
        {
            return new Theater();
        }
    }
}
