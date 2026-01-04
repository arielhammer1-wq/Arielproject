using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GenresInMoviesController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllGenresInMovies")]
        public GenresinMoviesList GetAll() => new GenresInMoviesDB().SelectAll();

        [HttpGet]
        [ActionName("SelectByIdxGenresInMovies{id}")]
        public GenresinMovies? GetById(int id) => GenresInMoviesDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertGenresInMovies")]
        public int Insert([FromBody] GenresinMovies gm)
        {
            var db = new GenresInMoviesDB();
            db.Insert(gm);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateGenresInMovies")]
        public int Update([FromBody] GenresinMovies gm)
        {
            var db = new GenresInMoviesDB();
            db.Update(gm);
            return db.SaveChanges();
        }

        [HttpDelete]
        [ActionName("DeleteGenresInMovies{id}")]
        public int Delete(int id)
        {
            var gm = GenresInMoviesDB.SelectById(id);
            if (gm == null) return 0;
            var db = new GenresInMoviesDB();
            db.Delete(gm);
            return db.SaveChanges();
        }
    }
}
