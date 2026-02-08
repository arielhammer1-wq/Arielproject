using Model;
using System;
using System.Data.OleDb;

namespace ViewModel
{
    public class TicketDB : BaseDB
    {
        public TicketList SelectAll()
        {
            command.CommandText = "SELECT * FROM Tickets";
            return new TicketList(base.Select());
        }

        protected override BaseEntity NewEntity() => new Ticket();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Ticket t = entity as Ticket;

            t.Id = Convert.ToInt32(reader["Id"]);
            t.SeatNumber = Convert.ToInt32(reader["SeatNumber"]);
            t.TicketPrice = Convert.ToInt32(reader["TicketPrice"]);

            int userId = Convert.ToInt32(reader["UserId"]);
            int movieId = Convert.ToInt32(reader["MovieId"]);
            int theaterId = Convert.ToInt32(reader["TheaterId"]);
            int hallId = Convert.ToInt32(reader["HallId"]);

            // Load related entities
            t.User = UserDB.SelectById(userId);
            t.Movie = MovieDB.SelectById(movieId);
            t.Theater = TheaterDB.SelectById(theaterId);
            t.Hall = MovieHallDB.SelectById(hallId);

            return t;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;

            cmd.CommandText = @"
                INSERT INTO Tickets
                (SeatNumber, TicketPrice, UserId, MovieId, TheaterId, HallId)
                VALUES
                (@seat, @price, @user, @movie, @theater, @hall)";

            cmd.Parameters.AddWithValue("@seat", t.SeatNumber);
            cmd.Parameters.AddWithValue("@price", t.TicketPrice);
            cmd.Parameters.AddWithValue("@user", t.User.Id);
            cmd.Parameters.AddWithValue("@movie", t.Movie.Id);
            cmd.Parameters.AddWithValue("@theater", t.Theater.Id);
            cmd.Parameters.AddWithValue("@hall", t.Hall.Id);
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;

            cmd.CommandText = @"
                UPDATE Tickets SET
                    SeatNumber=@seat,
                    TicketPrice=@price,
                    UserId=@user,
                    MovieId=@movie,
                    TheaterId=@theater,
                    HallId=@hall
                WHERE Id=@id";

            cmd.Parameters.AddWithValue("@seat", t.SeatNumber);
            cmd.Parameters.AddWithValue("@price", t.TicketPrice);
            cmd.Parameters.AddWithValue("@user", t.User.Id);
            cmd.Parameters.AddWithValue("@movie", t.Movie.Id);
            cmd.Parameters.AddWithValue("@theater", t.Theater.Id);
            cmd.Parameters.AddWithValue("@hall", t.Hall.Id);
            cmd.Parameters.AddWithValue("@id", t.Id);
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;

            cmd.CommandText = "DELETE FROM Tickets WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id", t.Id);
        }

        public static Ticket SelectById(int id)
        {
            TicketDB db = new TicketDB();
            foreach (BaseEntity e in db.SelectAll())
                if (((Ticket)e).Id == id)
                    return (Ticket)e;

            return null;
        }
    }
}
