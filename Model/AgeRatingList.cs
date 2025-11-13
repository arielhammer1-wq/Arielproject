using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AgeRatingList : List<AgeRating>
    {
        public AgeRatingList() { }

        public AgeRatingList(IEnumerable<AgeRating> list) : base(list) { }

        public AgeRatingList(IEnumerable<BaseEntity> list) : base(list.Cast<AgeRating>().ToList()) { }
    }
}
