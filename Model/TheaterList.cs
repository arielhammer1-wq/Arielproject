using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TheaterList : List<Theater>
    {
        public TheaterList() { }
        public TheaterList(IEnumerable<Theater> list) : base(list) { }
        public TheaterList(IEnumerable<BaseEntity> list) : base(list.Cast<Theater>().ToList()) { }
    }
}
