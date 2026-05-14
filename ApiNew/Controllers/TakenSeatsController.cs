using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
using System.Collections.Generic;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TakenSeatsController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllTakenSeats")]
        public TakenSeatsList GetAll() => new TakenSeatsDB().SelectAll();

        [HttpPost]
        [ActionName("InsertTakenSeat")]
        public int Insert([FromBody] TakenSeat ts)
        {
            var db = new TakenSeatsDB();
            db.Insert(ts);
            return db.SaveChanges();
        }

        [HttpDelete]
        [ActionName("DeleteTakenSeat{id}")]
        public int Delete(int id)
        {
            // Note: Since SelectById isn't static in my previous TakenSeatsDB example, 
            // we initialize the DB class first.
            var db = new TakenSeatsDB();
            var all = db.SelectAll();
            var ts = all.Find(x => x.Id == id);

            if (ts == null) return 0;

            db.Delete(ts);
            return db.SaveChanges();
        }

        // This is the most important one for your SeatSelection page
        [HttpGet]
        [ActionName("SelectByScreening/{movieId}/{hallId}")]
        public List<int> GetByScreening([FromRoute] int movieId, [FromRoute] int hallId)
        {
            return new TakenSeatsDB().SelectByScreening(movieId, hallId);
        }
    }
}