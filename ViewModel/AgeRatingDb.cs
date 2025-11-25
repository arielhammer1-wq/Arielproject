using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AgeRatingDB : BaseDB
    {
        public AgeRatingList SelectAll()
        {
            command.CommandText = "SELECT * FROM AgeRating";
            AgeRatingList list = new AgeRatingList(base.Select());
            return list;
        }
        public static AgeRating SelectById(int id)
        {
            AgeRatingDB db = new AgeRatingDB();
            AgeRatingList list = db.SelectAll();
            AgeRating g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            AgeRating ar = entity as AgeRating;
            ar.Id = Convert.ToInt32(reader["id"]);
            ar.AgeRatingName = reader["AgeRatingName"].ToString();
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new AgeRating();
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
