using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM Users";
            return new UserList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User u = entity as User;

            u.Id = Convert.ToInt32(reader["Id"]);
            u.Username = reader["Username"].ToString();
            u.Pass = reader["Pass"].ToString();
            u.Email = reader["Email"].ToString();

            return u;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;

            cmd.CommandText = @"INSERT INTO Users (Username, Pass, Email)
                                VALUES (@username, @pass, @email)";

            cmd.Parameters.Add(new OleDbParameter("@username", u.Username));
            cmd.Parameters.Add(new OleDbParameter("@pass", u.Pass));
            cmd.Parameters.Add(new OleDbParameter("@email", u.Email));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;

            cmd.CommandText = @"UPDATE Users 
                                SET Username=@username, Pass=@pass, Email=@email
                                WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@username", u.Username));
            cmd.Parameters.Add(new OleDbParameter("@pass", u.Pass));
            cmd.Parameters.Add(new OleDbParameter("@email", u.Email));
            cmd.Parameters.Add(new OleDbParameter("@id", u.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;

            cmd.CommandText = "DELETE FROM Users WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", u.Id));
        }

        public static User SelectById(int id)
        {
            UserDB db = new UserDB();
            UserList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }
    }
}
