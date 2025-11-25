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
        public CustomerList  SelectAll()
        {
            command.CommandText = "SELECT Customers.DateOfBirth, Customers.id, " +
                "Customers.gender, Customers.RepeatCustomer, Users.username, Users.Email," +
                " Users.pass\r\nFROM (Customers INNER JOIN\r\n Users ON Customers.id = " +
                "Users.id)";
            CustomerList list = new CustomerList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Customer c = entity as Customer;
            c.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
            c.CustomerGender = GenderDB.SelectById(int.Parse(reader["gender"].ToString()));
            c.RepeatCustomer = Convert.ToBoolean(reader["RepeatCustomer"]);
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Customer();
        }
    }
}
