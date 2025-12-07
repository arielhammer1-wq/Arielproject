using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM Users";
            UserList list = new UserList(base.Select());
            return list;
        }
        public static User SelectById(int id)
        {
            UserDB db = new UserDB();
            UserList list = db.SelectAll();
            User g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User u = entity as User;
            u.Id = Convert.ToInt32(reader["id"]);
            u.Username = reader["username"].ToString();
            u.Pass = reader["pass"].ToString();
            u.Email = reader["Email"].ToString();
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u != null)
            {
                string sqlStr = "UPDATE Users SET username=@userName ,pass=@pass,Email=@Email WHERE ID=@id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@userName", u.Username));
                cmd.Parameters.Add(new OleDbParameter("@pass", u.Pass));
                cmd.Parameters.Add(new OleDbParameter("@Email", u.Email));
                cmd.Parameters.Add(new OleDbParameter("@id", u.Id));
            }
        }
    }
}
