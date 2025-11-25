using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OperatorList : UserList
    {
        public OperatorList() { }
        public OperatorList(IEnumerable<Operator> list) : base(list) { }
        public OperatorList(IEnumerable<BaseEntity> list) : base(list.Cast<Operator>().ToList()) { }
    }
}
