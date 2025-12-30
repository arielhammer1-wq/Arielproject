using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{

    public class TheaterDB : BaseDB
    {
        public TheaterList SelectAll()
        {
            command.CommandText = "SELECT * FROM Theaters";
            return new TheaterList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new Theater();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Theater t = entity as Theater;

            t.Id = Convert.ToInt32(reader["Id"]);
            t.NameOfTheater = reader["NameOfTheater"].ToString();
            t.Address = reader["Address"].ToString();
            t.StreetNumber = Convert.ToInt32(reader["StreetNumber"]);

            int cityId = Convert.ToInt32(reader["CityCode"]);
            t.CityCode = CityDB.SelectById(cityId);

            return t;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Theater t = entity as Theater;

            cmd.CommandText =
                "INSERT INTO Theaters (NameOfTheater, Address, StreetNumber, CityCode) " +
                "VALUES (@name, @address, @street, @city)";

            cmd.Parameters.Add(new OleDbParameter("@name", t.NameOfTheater));
            cmd.Parameters.Add(new OleDbParameter("@address", t.Address));
            cmd.Parameters.Add(new OleDbParameter("@street", t.StreetNumber));
            cmd.Parameters.Add(new OleDbParameter("@city", t.CityCode.Id));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Theater t = entity as Theater;

            cmd.CommandText =
                "UPDATE Theaters SET NameOfTheater=@name, Address=@address, " +
                "StreetNumber=@street, CityCode=@city WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@name", t.NameOfTheater));
            cmd.Parameters.Add(new OleDbParameter("@address", t.Address));
            cmd.Parameters.Add(new OleDbParameter("@street", t.StreetNumber));
            cmd.Parameters.Add(new OleDbParameter("@city", t.CityCode.Id));
            cmd.Parameters.Add(new OleDbParameter("@id", t.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Theater t = entity as Theater;

            cmd.CommandText = "DELETE FROM Theaters WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", t.Id));
        }

        public static Theater SelectById(int id)
        {
            TheaterDB db = new TheaterDB();
            TheaterList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }
    }
}