using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
    namespace ViewModel
    {
        public class CityDB : BaseDB
        {
            public CityList SelectAll()
            {
                command.CommandText = "SELECT * FROM Citys";
                return new CityList(base.Select());
            }

            protected override BaseEntity CreateModel(BaseEntity entity)
            {
                City c = entity as City;
                c.Id = Convert.ToInt32(reader["Id"]);
                c.CityName = reader["CityName"].ToString();
                return c;
            }

            protected override BaseEntity NewEntity() => new City();

            public static City SelectById(int id)
            {
                CityDB db = new CityDB();
                CityList list = db.SelectAll();
                return list.Find(x => x.Id == id);
            }

            protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
            {
                City c = entity as City;
                cmd.CommandText = "DELETE FROM Citys WHERE Id=@id";
                cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
            }

            protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
            {
                City c = entity as City;
                cmd.CommandText = "INSERT INTO Citys (CityName) VALUES (@name)";
                cmd.Parameters.Add(new OleDbParameter("@name", c.CityName));
            }

            protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
            {
                City c = entity as City;
                cmd.CommandText = "UPDATE Citys SET CityName=@name WHERE Id=@id";
                cmd.Parameters.Add(new OleDbParameter("@name", c.CityName));
                cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
            }

        }
    }

