using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ticket : BaseEntity
    {
        public int TicketPrice { get; set; }
        public User User { get; set; }
        public MovieScreening Screening { get; set; }
        public int SeatNumber { get; set; }
    }
}
