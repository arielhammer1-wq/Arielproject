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

        protected override BaseEntity NewEntity() => new Ticket();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Ticket t = entity as Ticket;

            t.Id = Convert.ToInt32(reader["Id"]);
            t.TicketPrice = Convert.ToInt32(reader["TicketPrice"]);

            int userId = Convert.ToInt32(reader["UserId"]);
            int screeningId = Convert.ToInt32(reader["ScreeningId"]);

            // Load objects
            t.User = UserDB.SelectById(userId);
            t.Screening = MovieScreeningDB.SelectById(screeningId);

            return t;
        }


        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;

            cmd.CommandText = @"INSERT INTO Tickets (TicketPrice, UserId, ScreeningId)
                        VALUES (@price, @user, @screen)";

            cmd.Parameters.Add(new OleDbParameter("@price", t.TicketPrice));
            cmd.Parameters.Add(new OleDbParameter("@user", t.User.Id));
            cmd.Parameters.Add(new OleDbParameter("@screen", t.Screening.Id));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;

            cmd.CommandText = @"UPDATE Tickets 
                        SET TicketPrice=@price, UserId=@user, ScreeningId=@screen
                        WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@price", t.TicketPrice));
            cmd.Parameters.Add(new OleDbParameter("@user", t.User.Id));
            cmd.Parameters.Add(new OleDbParameter("@screen", t.Screening.Id));
            cmd.Parameters.Add(new OleDbParameter("@id", t.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Ticket t = entity as Ticket;

            cmd.CommandText = "DELETE FROM Tickets WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", t.Id));
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