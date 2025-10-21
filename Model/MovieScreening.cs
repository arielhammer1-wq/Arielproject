using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieScreening : BaseEntity
    {
        public int HallId { get; set; }
        public DateTime TimeOfScreening { get; set; }
        public string MovieScreened { get; set; }

        public Movie Movie { get; set; }

        public TicketList Tickets { get; set; } = new TicketList();
    }
}
