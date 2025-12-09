using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class MovieHallDB : BaseDB
    {
        public MovieHallList SelectAll()
        {
            command.CommandText = "SELECT * FROM movieHalls";
            return new MovieHallList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieHall();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieHall h = entity as MovieHall;

            h.Id = Convert.ToInt32(reader["Id"]);
            h.HallName = reader["HallName"].ToString();
            h.AmountOfSeats = Convert.ToInt32(reader["AmountOfSeats"]);

            int theaterId = Convert.ToInt32(reader["Theaterid"]);
            h.Theater = TheaterDB.SelectById(theaterId);

            return h;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieHall h = entity as MovieHall;

            cmd.CommandText =
                "INSERT INTO movieHalls (HallName, AmountOfSeats, Theaterid) " +
                "VALUES (@name, @seats, @theater)";

            cmd.Parameters.Add(new OleDbParameter("@name", h.HallName));
            cmd.Parameters.Add(new OleDbParameter("@seats", h.AmountOfSeats));
            cmd.Parameters.Add(new OleDbParameter("@theater", h.Theater.Id));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieHall h = entity as MovieHall;

            cmd.CommandText =
                "UPDATE movieHalls SET HallName=@name, AmountOfSeats=@seats, Theaterid=@theater " +
                "WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@name", h.HallName));
            cmd.Parameters.Add(new OleDbParameter("@seats", h.AmountOfSeats));
            cmd.Parameters.Add(new OleDbParameter("@theater", h.Theater.Id));
            cmd.Parameters.Add(new OleDbParameter("@id", h.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieHall h = entity as MovieHall;

            cmd.CommandText = "DELETE FROM movieHalls WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", h.Id));
        }

        public static MovieHall SelectById(int id)
        {
            MovieHallDB db = new MovieHallDB();
            MovieHallList list = db.SelectAll();
            return list.Find(x => x.Id == id);
        }
    }
}
