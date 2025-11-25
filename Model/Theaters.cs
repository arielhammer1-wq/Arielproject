using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Theater : BaseEntity
    {
        public string NameOfTheater { get; set; }
        public string Address { get; set; }
        public int StreetNumber { get; set; }

        public City CityCode { get; set; }

    }
}
