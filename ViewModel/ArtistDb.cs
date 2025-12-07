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

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Artist artist = entity as Artist;
            if (artist != null)
            {
                string sqlStr = "UPDATE Artists SET ArtistName=@AName,StartingYear=@SYear,role=@role WHERE ID=@id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@AName", artist.ArtistName));
                cmd.Parameters.Add(new OleDbParameter("@SYear", artist.StartingYear));
                cmd.Parameters.Add(new OleDbParameter("@role", artist.ArtistRole.Id));
                cmd.Parameters.Add(new OleDbParameter("@id", artist.Id));
            }
        }
    }
}
