using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ticket : BaseEntity
    {
        public int SeatNumber { get; set; }
        public int TicketPrice { get; set; }

        public Movie Movie { get; set; }
        public Theater Theater { get; set; }
        public MovieHall Hall { get; set; }

        public User User { get; set; }
    }
}
