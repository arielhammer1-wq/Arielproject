using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class CustomerDB : UserDB
    {
        public CustomerList SelectAll()
        {
            command.CommandText =
                "SELECT Customers.Id, Customers.DateOfBirth, Customers.Gender, Customers.RepeatCustomer, " +
                "Users.Username, Users.Email, Users.Pass " +
                "FROM Customers INNER JOIN Users ON Customers.Id = Users.Id";

            return new CustomerList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new Customer();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Customer c = entity as Customer;

            // Fill Customer-specific fields
            c.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
            c.CustomerGender = GenderDB.SelectById(Convert.ToInt32(reader["Gender"]));
            c.RepeatCustomer = Convert.ToBoolean(reader["RepeatCustomer"]);

            // Fill User fields (Username, Pass, Email)
            base.CreateModel(entity);

            return c;

        }
        public static Customer SelectById(int id)
        {
            CustomerDB C = new CustomerDB();
            CustomerList list =C.SelectAll();
            return list.Find(x => x.Id == id);
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Customer c = entity as Customer;

            cmd.CommandText =
                @"INSERT INTO Customers (id, DateOfBirth, Gender, RepeatCustomer)
          VALUES (@id, @DOB, @gender, @RepeatCustomer)";

            cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
            cmd.Parameters.Add(new OleDbParameter("@DOB", c.DateOfBirth));
            cmd.Parameters.Add(new OleDbParameter("@gender", c.CustomerGender.Id));
            cmd.Parameters.Add(new OleDbParameter("@RepeatCustomer", c.RepeatCustomer));
        }

        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();

            inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity));
            inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));

        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Customer c = entity as Customer;

            cmd.CommandText = @"DELETE FROM Customers WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
        }
        public override void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Customer c = entity as Customer;

            cmd.CommandText =
                @"UPDATE Customers 
          SET DateOfBirth=@DOB, 
              Gender=@gender, 
              RepeatCustomer=@RepeatCustomer
          WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@DOB", c.DateOfBirth));
            cmd.Parameters.Add(new OleDbParameter("@gender", c.CustomerGender.Id));
            cmd.Parameters.Add(new OleDbParameter("@RepeatCustomer", c.RepeatCustomer));
            cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
        }
        public override void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
            
        }

    }
}
