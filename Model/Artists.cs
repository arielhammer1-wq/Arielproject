using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Artist : BaseEntity
    {
        public string ArtistName { get; set; }
        public int StartingYear { get; set; }
        public Role ArtistRole { get; set; }
    } 
}
