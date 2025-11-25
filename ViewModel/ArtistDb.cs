using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ArtistDB : BaseDB
    {
        public ArtistList SelectAll()
        {
            command.CommandText = "SELECT * FROM Artists";
            ArtistList list = new ArtistList(base.Select());
            return list;
        }
        public static Artist SelectById(int id)
        {
            ArtistDB db = new ArtistDB();
            ArtistList list = db.SelectAll();
            Artist g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Artist a = entity as Artist;
            a.Id = Convert.ToInt32(reader["Id"]);
            a.ArtistName = reader["ArtistName"].ToString();
            a.StartingYear = Convert.ToInt32(reader["StartingYear"]);
            a.ArtistRole = RoleDB.SelectById(int.Parse(reader["role"].ToString()));


            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Artist();
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
