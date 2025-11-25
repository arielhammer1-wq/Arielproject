using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RoleDB : BaseDB
    {
        public static Role SelectById(int id)
        {
            RoleDB db = new RoleDB();
            RoleList list = db.SelectAll();
            Role g = list.Find(item => item.Id == id);
            return g;
        }
        public RoleList SelectAll()
        {
            command.CommandText = "SELECT * FROM Role";
            RoleList list = new RoleList(base.Select());
            return list;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Role r = entity as Role;
            r.Id = Convert.ToInt32(reader["Id"]);
            r.RoleName = RoleDB.SelectById(int.Parse(reader["RoleName"].ToString()));

            base.CreateModel(entity);
            return entity;
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity NewEntity()
        {
            return new Role();
        }
    }
}
