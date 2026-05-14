using Model;
using System;
using System.Collections.Generic;
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

        protected override BaseEntity NewEntity()
        {
            return new Ticket();
        }

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

            t.User = UserDB.SelectById(userId);
            t.Movie = MovieDB.SelectById(movieId);
            t.Theater = TheaterDB.SelectById(theaterId);
            t.Hall = MovieHallDB.SelectById(hallId);

            return t;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;
            if (t != null)
            {
                cmd.CommandText =
                    "INSERT INTO Tickets (SeatNumber, TicketPrice, UserId, MovieId, TheaterId, HallId) " +
                    "VALUES (@seat, @price, @user, @movie, @theater, @hall)";

                cmd.Parameters.Add(new OleDbParameter("@seat", t.SeatNumber));
                cmd.Parameters.Add(new OleDbParameter("@price", t.TicketPrice));
                cmd.Parameters.Add(new OleDbParameter("@user", t.User.Id));
                cmd.Parameters.Add(new OleDbParameter("@movie", t.Movie.Id));
                cmd.Parameters.Add(new OleDbParameter("@theater", t.Theater.Id));
                cmd.Parameters.Add(new OleDbParameter("@hall", t.Hall.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;
            if (t != null)
            {
                cmd.CommandText =
                    "UPDATE Tickets SET SeatNumber=@seat, TicketPrice=@price, UserId=@user, " +
                    "MovieId=@movie, TheaterId=@theater, HallId=@hall WHERE Id=@id";

                cmd.Parameters.Add(new OleDbParameter("@seat", t.SeatNumber));
                cmd.Parameters.Add(new OleDbParameter("@price", t.TicketPrice));
                cmd.Parameters.Add(new OleDbParameter("@user", t.User.Id));
                cmd.Parameters.Add(new OleDbParameter("@movie", t.Movie.Id));
                cmd.Parameters.Add(new OleDbParameter("@theater", t.Theater.Id));
                cmd.Parameters.Add(new OleDbParameter("@hall", t.Hall.Id));
                cmd.Parameters.Add(new OleDbParameter("@id", t.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;
            if (t != null)
            {
                cmd.CommandText = "DELETE FROM Tickets WHERE Id=@id";
                cmd.Parameters.Add(new OleDbParameter("@id", t.Id));
            }
        }

        public static Ticket SelectById(int id)
        {
            TicketDB db = new TicketDB();
            TicketList list = db.SelectAll();
            Ticket t = list.Find(item => item.Id == id);
            return t;
        }

        public List<int> GetTakenSeats(int movieId, int theaterId, int hallId)
        {
            List<int> takenSeats = new List<int>();

            command.Parameters.Clear();

            command.CommandText =
                "SELECT SeatNumber FROM Tickets " +
                "WHERE MovieId=@movieId AND TheaterId=@theaterId AND HallId=@hallId";

            command.Parameters.Add(new OleDbParameter("@movieId", movieId));
            command.Parameters.Add(new OleDbParameter("@theaterId", theaterId));
            command.Parameters.Add(new OleDbParameter("@hallId", hallId));

            try
            {
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    takenSeats.Add(Convert.ToInt32(reader["SeatNumber"]));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Database Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return takenSeats;
        }
    }
}