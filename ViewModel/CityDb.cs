using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class CityDB : BaseDB
    {
        // Select all cities
        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM Citys";
            CityList cityList = new CityList(base.Select());
            return cityList;
        }

        // Map data from database to model
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City c = entity as City;
            c.Id = Convert.ToInt32(reader["Id"]);
            c.CityName = reader["CityName"].ToString();
            return c;
        }

        // Create a new instance of the entity
        protected override BaseEntity NewEntity()
        {
            return new City();
        }

        // Select by Id helper
        public static City SelectById(int id)
        {
            CityDB db = new CityDB();
            CityList list = db.SelectAll();
            City g = list.Find(item => item.Id == id);
            return g;
        }

        // DELETE operation
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City c = entity as City;
            if (c != null)
            {
                string sqlStr = "DELETE FROM Citys WHERE Id=@id";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }

        // INSERT operation — **must rename from CreateInsertdSQL to CreateInsertSQL**
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City c = entity as City;
            if (c != null)
            {
                string sqlStr = "INSERT INTO Citys (CityName) VALUES (@cName)";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@cName", c.CityName));
            }
        }

        // UPDATE operation
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City c = entity as City;
            if (c != null)
            {
                string sqlStr = "UPDATE Citys SET CityName=@cName WHERE Id=@id";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@cName", c.CityName));
                cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
    }
}
