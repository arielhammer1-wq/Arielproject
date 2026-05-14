using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class TakenSeatsDB : BaseDB
    {
        public TakenSeatsList SelectAll()
        {
            command.CommandText = "SELECT * FROM TakenSeats";
            return new TakenSeatsList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new TakenSeat();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            TakenSeat ts = entity as TakenSeat;

            ts.Id = Convert.ToInt32(reader["Id"]);
            ts.MovieId = Convert.ToInt32(reader["MovieId"]);
            ts.HallId = Convert.ToInt32(reader["HallId"]);
            ts.SeatNumber = Convert.ToInt32(reader["SeatNumber"]);

            return ts;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            TakenSeat ts = entity as TakenSeat;

            cmd.CommandText =
                "INSERT INTO TakenSeats (MovieId, HallId, SeatNumber) VALUES (@mId, @hId, @sNum)";

            cmd.Parameters.Add(new OleDbParameter("@mId", ts.MovieId));
            cmd.Parameters.Add(new OleDbParameter("@hId", ts.HallId));
            cmd.Parameters.Add(new OleDbParameter("@sNum", ts.SeatNumber));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            TakenSeat ts = entity as TakenSeat;

            cmd.CommandText =
                "UPDATE TakenSeats SET MovieId=@mId, HallId=@hId, SeatNumber=@sNum WHERE Id=@id";

            cmd.Parameters.Add(new OleDbParameter("@mId", ts.MovieId));
            cmd.Parameters.Add(new OleDbParameter("@hId", ts.HallId));
            cmd.Parameters.Add(new OleDbParameter("@sNum", ts.SeatNumber));
            cmd.Parameters.Add(new OleDbParameter("@id", ts.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            TakenSeat ts = entity as TakenSeat;

            cmd.CommandText = "DELETE FROM TakenSeats WHERE Id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", ts.Id));
        }

        // Helper to get seats for a specific screening
        public List<int> SelectByScreening(int movieId, int hallId)
        {
            TakenSeatsList all = SelectAll();
            List<int> taken = new List<int>();

            foreach (var item in all)
            {
                if (item.MovieId == movieId && item.HallId == hallId)
                    taken.Add(item.SeatNumber);
            }
            return taken;
        }
    }
}