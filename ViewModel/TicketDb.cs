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
            t.Id = Convert.ToInt32(reader["id"]);
            t.TicketPrice = Convert.ToInt32(reader["TicketPrice"]);
            t.User = new User
            {
                Id = Convert.ToInt32(reader["UserId"])
            };
            t.Screening = new MovieScreening
            {
                Id = Convert.ToInt32(reader["ScreeningId"])
            };
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Ticket();
        }
    }
}
