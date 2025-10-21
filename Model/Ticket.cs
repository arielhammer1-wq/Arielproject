using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ticket : BaseEntity
    {
        public decimal TicketPrice { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ScreeningId { get; set; }
        public MovieScreening Screening { get; set; }
    }
}
