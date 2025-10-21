using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CityDB : BaseDB
    {
        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM CityTbl";
            CityList cityList = new CityList(base.Select());
            return cityList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City c = entity as City;
            c.CityName = reader["CityName"].ToString();
            c.TheaterId = Convert.ToInt32(reader["TheaterId"]);
            return base.CreateModel(entity);
        }
        protected override BaseEntity NewEntity()
        {
            return new City();
        }
    }
}