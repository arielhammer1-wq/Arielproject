using Model;
using System;
using System.Data.OleDb;

namespace ViewModel
{
    public class OperatorDB : UserDB
    {
        public OperatorList SelectAll()
        {
            command.CommandText =
                "SELECT Operators.Id, Operators.RoleName, " +
                "Users.Username, Users.Email, Users.Pass " +
                "FROM Operators INNER JOIN Users ON Operators.Id = Users.Id";

            return new OperatorList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new Operator();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Operator op = entity as Operator;

            // Operator fields
            op.RoleName = RoleDB.SelectById(Convert.ToInt32(reader["RoleName"]));

            // User fields
            base.CreateModel(entity);

            return op;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Operator op = entity as Operator;

            cmd.CommandText =
                "INSERT INTO Operators (Id, RoleName) " +
                "VALUES (@id, @role)";

            cmd.Parameters.Add(new OleDbParameter("@id", op.Id));
            cmd.Parameters.Add(new OleDbParameter("@role", op.RoleName.Id));
        }

        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                // Insert into Users table
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity));

                // Insert into Operators table
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Operator op = entity as Operator;

            cmd.CommandText =
                "UPDATE Operators SET RoleName=@role WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@role", op.RoleName.Id));
            cmd.Parameters.Add(new OleDbParameter("@id", op.Id));
        }

        public override void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                // Update Users
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));

                // Update Operators
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Operator op = entity as Operator;

            cmd.CommandText = "DELETE FROM Operators WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", op.Id));
        }

        public override void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                // Delete from Operators table
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));

                // Delete from Users table
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }
    }
}
