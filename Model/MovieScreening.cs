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
        public MovieHall HallId { get; set; }
        public DateTime TimeOfScreening { get; set; }
        public Movie MovieScreened { get; set; }

    }
}
