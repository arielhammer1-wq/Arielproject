using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TheaterController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllTheaters")]
        public TheaterList GetAll() => new TheaterDB().SelectAll();

        [HttpGet]
        [ActionName("SelectByIdxTheater{id}")]
        public Theater? GetById(int id) => TheaterDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertTheater")]
        public int Insert([FromBody] Theater t)
        {
            var db = new TheaterDB();
            db.Insert(t);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateTheater")]
        public int Update([FromBody] Theater t)
        {
            var db = new TheaterDB();
            db.Update(t);
            return db.SaveChanges();
        }

        [HttpDelete]
        [ActionName("DeleteTheater{id}")]
        public int Delete(int id)
        {
            var t = TheaterDB.SelectById(id);
            if (t == null) return 0;
            var db = new TheaterDB();
            db.Delete(t);
            return db.SaveChanges();
        }
    }
}
