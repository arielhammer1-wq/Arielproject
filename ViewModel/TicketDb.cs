using Model;
using System;
using System.Collections.Generic;
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

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Ticket t = entity as Ticket;
            t.TicketPrice = Convert.ToDecimal(reader["TicketPrice"]);
            t.UserId = Convert.ToInt32(reader["UserId"]);
            t.ScreeningId = Convert.ToInt32(reader["ScreeningId"]);
            return base.CreateModel(entity);
        }

        protected override BaseEntity NewEntity()
        {
            return new Ticket();
        }
    }

}
