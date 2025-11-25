using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OperatorDB : UserDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Operator o = entity as Operator;
            base.CreateModel(o);
            //o.RoleName = RoleDB.SelectById((int)reader["role"].ToString());
            return o;
        }

        protected override BaseEntity NewEntity()
        {
            return new Operator();
        }
    }

}
