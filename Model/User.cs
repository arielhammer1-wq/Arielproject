using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public int Roleid { get; set; }
    }
}
