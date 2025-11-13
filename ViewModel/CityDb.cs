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
            command.CommandText = "SELECT * FROM Citys";
            CityList cityList = new CityList(base.Select());
            return cityList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City c = entity as City;
            c.Id = Convert.ToInt32(reader["Id"]);
            c.CityName = reader["CityName"].ToString();
            return c;
        }


        protected override BaseEntity NewEntity()
        {
            return new City();
        }
    }
}