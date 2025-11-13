using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RoleDB : BaseDB
    {
        public RoleList SelectAll()
        {
            command.CommandText = "SELECT * FROM Role";
            RoleList list = new RoleList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Role r = entity as Role;
            r.Id = Convert.ToInt32(reader["RoleId"]);
            r.Rolename = reader["RoleName"].ToString();
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Role();
        }
    }
}
