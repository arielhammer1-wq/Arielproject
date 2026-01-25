using Model;
using System;
using System.Data.OleDb;

namespace ViewModel
{
    public class AgeRatingDB : BaseDB
    {
        public AgeRatingList SelectAll()
        {
            command.CommandText = "SELECT * FROM AgeRating";
            return new AgeRatingList(base.Select());
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            AgeRating a = entity as AgeRating;
            a.Id = Convert.ToInt32(reader["Id"]);
            a.AgeRatingName = reader["AgeRatingName"].ToString();
            return a;
        }

        protected override BaseEntity NewEntity() => new AgeRating();

        public static AgeRating SelectById(int id)
        {
            AgeRatingDB db = new AgeRatingDB();
            AgeRatingList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AgeRating a = entity as AgeRating;
            cmd.CommandText = "DELETE FROM AgeRating WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", a.Id));
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AgeRating a = entity as AgeRating;
            cmd.CommandText = "INSERT INTO AgeRating (AgeRatingName) VALUES (@name)";
            cmd.Parameters.Add(new OleDbParameter("@name", a.AgeRatingName));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AgeRating a = entity as AgeRating;
            cmd.CommandText = "UPDATE AgeRating SET AgeRatingName=@name WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@name", a.AgeRatingName));
            cmd.Parameters.Add(new OleDbParameter("@id", a.Id));
        }
    }
}