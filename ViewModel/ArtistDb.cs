using Model;
using System;
using System.Collections.Generic;
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

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Artist a = entity as Artist;
            a.ArtistName = reader["ArtistName"].ToString();
            a.StartingYear = Convert.ToInt32(reader["StartingYear"]);
            a.Role = reader["role"].ToString();
            return base.CreateModel(entity);
        }

        protected override  BaseEntity NewEntity()
        {
            return new Artist();
        }
    }

}
