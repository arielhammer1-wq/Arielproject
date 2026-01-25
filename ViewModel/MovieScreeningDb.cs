using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieScreeningDB : BaseDB
    {
        public MovieScreeningList SelectAll()
        {
            command.CommandText = "SELECT * FROM movieScreenings";
            return new MovieScreeningList(base.Select());
        }
        public static MovieScreening SelectById(int id)
        {
            MovieScreeningDB db = new MovieScreeningDB();
            MovieScreeningList list = db.SelectAll();
            return list.Find(ms => ms.Id == id);
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieScreening s = entity as MovieScreening;
            cmd.CommandText = "INSERT INTO movieScreenings (MovieScreened, hallid, TimeOfScreening) VALUES (@movie,@hall,@time)";
            cmd.Parameters.Add(new OleDbParameter("@movie", s.MovieScreened));
            cmd.Parameters.Add(new OleDbParameter("@hall", s.HallId));
            cmd.Parameters.Add(new OleDbParameter("@time", s.TimeOfScreening));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieScreening s = entity as MovieScreening;
            cmd.CommandText = "UPDATE movieScreenings SET MovieScreened=@movie, hallid=@hall, TimeOfScreening=@time WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@movie", s.MovieScreened));
            cmd.Parameters.Add(new OleDbParameter("@hall", s.HallId));
            cmd.Parameters.Add(new OleDbParameter("@time", s.TimeOfScreening));
            cmd.Parameters.Add(new OleDbParameter("@id", s.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieScreening s = entity as MovieScreening;
            cmd.CommandText = "DELETE FROM movieScreenings WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", s.Id));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieScreening s = entity as MovieScreening;
            s.Id = Convert.ToInt32(reader["Id"]);
            s.MovieScreened =MovieDB.SelectById(Convert.ToInt32(reader["MovieScreened"]));
            s.HallId = MovieHallDB.SelectById(Convert.ToInt32(reader["HallId"]));
            s.TimeOfScreening = Convert.ToDateTime(reader["TimeOfScreening"]);
            return s;
        }

        protected override BaseEntity NewEntity() => new MovieScreening();
    }
}
