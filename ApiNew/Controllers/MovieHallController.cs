using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieHallController : ControllerBase
    {
        [HttpGet("SelectAllMovieHalls")]
        public MovieHallList GetAll() => new MovieHallDB().SelectAll();

        [HttpGet("SelectByIdxMovieHall{id}")]
        public MovieHall? GetById(int id) => MovieHallDB.SelectById(id);

        [HttpPost("InsertMovieHall")]
        public int Insert([FromBody] MovieHall h)
        {
            var db = new MovieHallDB();
            db.Insert(h);
            return db.SaveChanges();
        }

        [HttpPut("UpdateMovieHall")]
        public int Update([FromBody] MovieHall h)
        {
            var db = new MovieHallDB();
            db.Update(h);
            return db.SaveChanges();
        }

        [HttpDelete("DeleteMovieHall{id}")]
        public int Delete(int id)
        {
            var h = MovieHallDB.SelectById(id);
            if (h == null) return 0;
            var db = new MovieHallDB();
            db.Delete(h);
            return db.SaveChanges();
        }
    }
}
