using Model;
using System;
using System.Data.OleDb;

namespace ViewModel
{
    public class RoleDB : BaseDB
    {
        public RoleList SelectAll()
        {
            command.CommandText = "SELECT * FROM Role";
            return new RoleList(base.Select());
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Role r = entity as Role;
            r.Id = Convert.ToInt32(reader["Id"]);
            r.RoleName = reader["RoleName"].ToString();
            return r;
        }

        protected override BaseEntity NewEntity() => new Role();

        public static Role SelectById(int id)
        {
            RoleDB db = new RoleDB();
            RoleList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Role r = entity as Role;
            cmd.CommandText = "DELETE FROM Role WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Role r = entity as Role;
            cmd.CommandText = "INSERT INTO Role (RoleName) VALUES (@name)";
            cmd.Parameters.Add(new OleDbParameter("@name", r.RoleName));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Role r = entity as Role;
            cmd.CommandText = "UPDATE Role SET RoleName=@name WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@name", r.RoleName));
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
        }
    }
}