using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieGenreController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllMovieGenres")]
        public MovieGenreList GetAll() => new MovieGenreDB().SelectAll();

        [HttpGet]
        [ActionName("SelectByIdxMovieGenre{id}")]
        public MovieGenre? GetById(int id) => MovieGenreDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertMovieGenre")]
        public int Insert([FromBody] MovieGenre g)
        {
            var db = new MovieGenreDB();
            db.Insert(g);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateMovieGenre")]
        public int Update([FromBody] MovieGenre g)
        {
            var db = new MovieGenreDB();
            db.Update(g);
            return db.SaveChanges();
        }

        [HttpDelete]
        [ActionName("DeleteMovieGenre{id}")]
        public int Delete(int id)
        {
            var g = MovieGenreDB.SelectById(id);
            if (g == null) return 0;
            var db = new MovieGenreDB();
            db.Delete(g);
            return db.SaveChanges();
        }
    }
}
