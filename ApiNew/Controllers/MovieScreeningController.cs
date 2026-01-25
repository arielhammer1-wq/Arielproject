using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieScreeningController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllMovieScreenings")]
        public MovieScreeningList GetAll() => new MovieScreeningDB().SelectAll();

        [HttpGet]
        [ActionName("SelectByIdxMovieScreening{id}")]
        public MovieScreening? GetById(int id) => MovieScreeningDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertMovieScreening")]
        public int Insert([FromBody] MovieScreening ms)
        {
            var db = new MovieScreeningDB();
            db.Insert(ms);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateMovieScreening")]
        public int Update([FromBody] MovieScreening ms)
        {
            var db = new MovieScreeningDB();
            db.Update(ms);
            return db.SaveChanges();
        }

        [HttpDelete]
        [ActionName("DeleteMovieScreening{id}")]
        public int Delete(int id)
        {
            var ms = MovieScreeningDB.SelectById(id);
            if (ms == null) return 0;
            var db = new MovieScreeningDB();
            db.Delete(ms);
            return db.SaveChanges();
        }
    }
}
