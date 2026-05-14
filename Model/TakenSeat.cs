namespace Model
{
    public class TakenSeat:BaseEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public int SeatNumber { get; set; }
    }
}