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
            MovieScreeningList list = new MovieScreeningList(base.Select());
            return list;
        }
        public static MovieScreening SelectById(int id)
        {
            MovieScreeningDB db = new MovieScreeningDB();
            MovieScreeningList list = db.SelectAll();
            MovieScreening g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieScreening s = entity as MovieScreening;
            s.Id = Convert.ToInt32(reader["id"]);
            s.HallId = MovieHallDB.SelectById(Convert.ToInt32(reader["hallid"]));
            s.TimeOfScreening = (DateTime)reader["TimeOfScreening"];
            s.MovieScreened = MovieDB.SelectById(Convert.ToInt32(reader["MovieScreened"]));
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieScreening();
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
            MovieScreening ms = entity as MovieScreening;
            if (ms != null)
            {
                string sqlStr = "UPDATE movieScreenings SET hallid=@hid, TimeOfScreening=@TOS, MovieScreened=@MS WHERE ID=@id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add("@hid", OleDbType.Integer).Value = ms.HallId.Id;

                OleDbParameter tosParam = new OleDbParameter("@TOS", OleDbType.DBDate);
                tosParam.Value = ms.TimeOfScreening;
                cmd.Parameters.Add(tosParam);

                cmd.Parameters.Add("@MS", OleDbType.Integer).Value = ms.MovieScreened.Id;
                cmd.Parameters.Add("@id", OleDbType.Integer).Value = ms.Id;
            }
        }

    }
}
