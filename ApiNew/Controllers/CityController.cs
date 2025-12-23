using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
using ViewModel.ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CityController : ControllerBase
    {
        [HttpGet("SelectAllCities")]
        public CityList GetAll() => new CityDB().SelectAll();

        [HttpGet("SelectByIdxCity{id}")]
        public City? GetById(int id) => CityDB.SelectById(id);

        [HttpPost("InsertCity")]
        public int Insert([FromBody] City c)
        {
            var db = new CityDB();
            db.Insert(c);
            return db.SaveChanges();
        }

        [HttpPut("UpdateCity")]
        public int Update([FromBody] City c)
        {
            var db = new CityDB();
            db.Update(c);
            return db.SaveChanges();
        }

        [HttpDelete("DeleteCity{id}")]
        public int Delete(int id)
        {
            var c = CityDB.SelectById(id);
            if (c == null) return 0;
            var db = new CityDB();
            db.Delete(c);
            return db.SaveChanges();
        }
    }
}
