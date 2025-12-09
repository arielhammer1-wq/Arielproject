using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class ArtistDB : BaseDB
    {
        public ArtistList SelectAll()
        {
            command.CommandText = "SELECT * FROM Artists";
            return new ArtistList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new Artist();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Artist a = entity as Artist;

            a.Id = Convert.ToInt32(reader["Id"]);
            a.ArtistName = reader["ArtistName"].ToString();
            a.StartingYear = Convert.ToInt32(reader["StartingYear"]);

            int roleId = Convert.ToInt32(reader["role"]);
            a.ArtistRole = RoleDB.SelectById(roleId);

            return a;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Artist a = entity as Artist;

            cmd.CommandText =
                @"INSERT INTO Artists (ArtistName, StartingYear, role)
                  VALUES (@name, @year, @role)";

            cmd.Parameters.Add(new OleDbParameter("@name", a.ArtistName));
            cmd.Parameters.Add(new OleDbParameter("@year", a.StartingYear));
            cmd.Parameters.Add(new OleDbParameter("@role", a.ArtistRole.Id));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Artist a = entity as Artist;

            cmd.CommandText =
                @"UPDATE Artists 
                  SET ArtistName=@name, StartingYear=@year, role=@role
                  WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@name", a.ArtistName));
            cmd.Parameters.Add(new OleDbParameter("@year", a.StartingYear));
            cmd.Parameters.Add(new OleDbParameter("@role", a.ArtistRole.Id));
            cmd.Parameters.Add(new OleDbParameter("@id", a.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Artist a = entity as Artist;

            cmd.CommandText = "DELETE FROM Artists WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", a.Id));
        }

        public static Artist SelectById(int id)
        {
            ArtistDB db = new ArtistDB();
            ArtistList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }
    }
}
