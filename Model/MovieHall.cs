using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieHall : BaseEntity
    {
        public string HallName { get; set; }
        public int AmountOfSeats { get; set; }
        public Theater Theater { get; set; }
    }
}
