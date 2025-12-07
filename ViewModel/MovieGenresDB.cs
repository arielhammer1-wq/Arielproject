using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieGenreDB : BaseDB
    {
        public MovieGenreList SelectAll()
        {
            command.CommandText = "SELECT * FROM MovieGenres";
            MovieGenreList MovieGenreList = new MovieGenreList(base.Select());
            return MovieGenreList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieGenre c = entity as MovieGenre;
            c.Id = Convert.ToInt32(reader["Id"]);
            c.GenreName = reader["GenreName"].ToString();
            return c;
        }


        protected override BaseEntity NewEntity()
        {
            return new MovieGenre();
        }
        public static MovieGenre SelectById(int id)
        {
            MovieGenreDB db = new MovieGenreDB();
            MovieGenreList list = db.SelectAll();
            MovieGenre g = list.Find(item => item.Id == id);
            return g;
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
            MovieGenre mg = entity as MovieGenre;
            if (mg != null)
            {
                string sqlStr = "UPDATE MovieGenres SET GenreName=@GenreName WHERE ID=@id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(new OleDbParameter("@GenreName", mg.GenreName));
                cmd.Parameters.Add(new OleDbParameter("@id", mg.Id));
            }
        }
    }
}