using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TheaterController : ControllerBase
    {
        [HttpGet("SelectAllTheaters")]
        public TheaterList GetAll() => new TheaterDB().SelectAll();

        [HttpGet("SelectByIdxTheater{id}")]
        public Theater? GetById(int id) => TheaterDB.SelectById(id);

        [HttpPost("InsertTheater")]
        public int Insert([FromBody] Theater t)
        {
            var db = new TheaterDB();
            db.Insert(t);
            return db.SaveChanges();
        }

        [HttpPut("UpdateTheater")]
        public int Update([FromBody] Theater t)
        {
            var db = new TheaterDB();
            db.Update(t);
            return db.SaveChanges();
        }

        [HttpDelete("DeleteTheater{id}")]
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
