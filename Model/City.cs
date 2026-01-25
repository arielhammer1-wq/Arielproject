using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }

        public override string ToString()
        {
            return base.ToString() + CityName;
        }
    }
}
