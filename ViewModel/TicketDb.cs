using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TicketDB : BaseDB
    {
        public TicketList SelectAll()
        {
            command.CommandText = "SELECT * FROM Tickets";
            TicketList list = new TicketList(base.Select());
            return list;
        }
        public static Ticket SelectById(int id)
        {
            TicketDB db = new TicketDB();
            TicketList list = db.SelectAll();
            Ticket g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Ticket t = entity as Ticket;
            t.Id = Convert.ToInt32(reader["id"]);
            t.TicketPrice = Convert.ToInt32(reader["TicketPrice"]);
            t.User =UserDB.SelectById(int.Parse(reader["Userid"].ToString()));
            t.Screening = MovieScreeningDB.SelectById(int.Parse(reader["Screeningid"].ToString()));
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Ticket();
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
            Ticket tk = entity as Ticket;
            if (tk != null)
            {
                string sqlStr = "UPDATE Tickets SET ScreeningId=@screeningId, TicketPrice=@price WHERE ID=@id";
                cmd.CommandText = sqlStr;

                cmd.Parameters.Add("@screeningId", OleDbType.Integer).Value = tk.Screening.Id;
                cmd.Parameters.Add("@price", OleDbType.Currency).Value = tk.TicketPrice;  // or OleDbType.Double if not currency
                cmd.Parameters.Add("@id", OleDbType.Integer).Value = tk.Id;
            }
        }
    }
}
