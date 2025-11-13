using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UsersDB : BaseDB
    {
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM Users";
            UserList list = new UserList(base.Select());
            return list;
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
    }
}
