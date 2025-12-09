using Model;
using System;
using System.Data.OleDb;

namespace ViewModel
{
    public class GenderDB : BaseDB
    {
        public GenderList SelectAll()
        {
            command.CommandText = "SELECT * FROM Gender";
            return new GenderList(base.Select());
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Gender g = entity as Gender;
            g.Id = Convert.ToInt32(reader["Id"]);
            g.GenderName = reader["GenderName"].ToString();
            return g;
        }

        protected override BaseEntity NewEntity() => new Gender();

        public static Gender SelectById(int id)
        {
            GenderDB db = new GenderDB();
            GenderList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Gender g = entity as Gender;
            cmd.CommandText = "DELETE FROM Gender WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", g.Id));
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Gender g = entity as Gender;
            cmd.CommandText = "INSERT INTO Gender (GenderName) VALUES (@name)";
            cmd.Parameters.Add(new OleDbParameter("@name", g.GenderName));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Gender g = entity as Gender;
            cmd.CommandText = "UPDATE Gender SET GenderName=@name WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@name", g.GenderName));
            cmd.Parameters.Add(new OleDbParameter("@id", g.Id));
        }
    }
}