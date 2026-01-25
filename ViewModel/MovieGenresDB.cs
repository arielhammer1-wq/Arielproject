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
            return new MovieGenreList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieGenre();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieGenre g = entity as MovieGenre;

            g.Id = Convert.ToInt32(reader["Id"]);
            g.GenreName = reader["GenreName"].ToString();

            return g;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieGenre g = entity as MovieGenre;

            cmd.CommandText =
                "INSERT INTO MovieGenres (GenreName) VALUES (@name)";

            cmd.Parameters.Add(new OleDbParameter("@name", g.GenreName));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieGenre g = entity as MovieGenre;

            cmd.CommandText =
                "UPDATE MovieGenres SET GenreName=@name WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@name", g.GenreName));
            cmd.Parameters.Add(new OleDbParameter("@id", g.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieGenre g = entity as MovieGenre;

            cmd.CommandText =
                "DELETE FROM MovieGenres WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@id", g.Id));
        }

        public static MovieGenre SelectById(int id)
        {
            MovieGenreDB db = new MovieGenreDB();
            MovieGenreList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }
    }
}