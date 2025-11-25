using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer : User
    {
        public DateTime DateOfBirth  { get; set; }
        public Gender CustomerGender { get; set; }
        public bool RepeatCustomer { get; set; }
    }
}
