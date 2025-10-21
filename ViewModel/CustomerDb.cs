using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomerDB : UserDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Customer c = entity as Customer;
            base.CreateModel(c);
            c.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
            c.Gender = reader["gender"].ToString();
            c.RepeatCustomer = Convert.ToBoolean(reader["RepeatCustomer"]);
            return c;
        }

        protected override BaseEntity NewEntity()
        {
            return new Customer();
        }
    }

}
