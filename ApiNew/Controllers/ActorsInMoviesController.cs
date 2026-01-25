using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ActorsInMovieController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllActorsInMovies")]
        public ActorsInMovieList GetAll() => new ActorsInMovieDB().SelectAll();

        [HttpGet]
        [ActionName("SelectByIdxActorsInMovie{id}")]
        public ActorsInMovie? GetById(int id) => ActorsInMovieDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertActorsInMovie")]
        public int Insert([FromBody] ActorsInMovie aim)
        {
            var db = new ActorsInMovieDB();
            db.Insert(aim);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateActorsInMovie")]
        public int Update([FromBody] ActorsInMovie aim)
        {
            var db = new ActorsInMovieDB();
            db.Update(aim);
            return db.SaveChanges();
        }

        [HttpDelete]
        [ActionName("DeleteActorsInMovie{id}")]
        public int Delete(int id)
        {
            var aim = ActorsInMovieDB.SelectById(id);
            if (aim == null) return 0;
            var db = new ActorsInMovieDB();
            db.Delete(aim);
            return db.SaveChanges();
        }
    }
}
