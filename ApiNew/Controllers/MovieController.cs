using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllMovies")]
        public MovieList GetAll() => new MovieDB().SelectAll();

        [HttpGet]
        [ActionName("SelectByIdxMovie{id}")]
        public Movie? GetById(int id) => MovieDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertMovie")]
        public int Insert([FromBody] Movie m)
        {
            var db = new MovieDB();
            db.Insert(m);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateMovie")]
        public int Update([FromBody] Movie m)
        {
            var db = new MovieDB();
            db.Update(m);
            return db.SaveChanges();
        }

        [HttpDelete]
        [ActionName("DeleteMovie{id}")]
        public int Delete(int id)
        {
            var m = MovieDB.SelectById(id);
            if (m == null) return 0;
            var db = new MovieDB();
            db.Delete(m);
            return db.SaveChanges();
        }
    }
}
