using Model;
using System.Collections.Generic;

namespace ViewModel
{
    public class TakenSeatsList : List<TakenSeat>
    {
        public TakenSeatsList() { }
        public TakenSeatsList(IEnumerable<TakenSeat> list) : base(list) { }
        public TakenSeatsList(IEnumerable<BaseEntity> list)
        {
            foreach (BaseEntity item in list)
            {
                this.Add(item as TakenSeat);
            }
        }
    }
}