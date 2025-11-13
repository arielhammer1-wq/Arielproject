using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomersDB : BaseDB
    {
        public CustomerList SelectAll()
        {
            command.CommandText = "SELECT * FROM Customers";
            CustomerList list = new CustomerList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Customer c = entity as Customer;
            c.Id = Convert.ToInt32(reader["id"]);
            c.Username = reader["username"].ToString();
            c.Pass = reader["pass"].ToString();
            c.Email = reader["email"].ToString();
            c.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
            c.CustomerGender = new Gender
            {
                Id = Convert.ToInt32(reader["gender"])
            };
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
