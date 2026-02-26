using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgeRatingController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllAgeRatings")]
        public AgeRatingList GetAll() => new AgeRatingDB().SelectAll();

        [HttpGet("{id}")]
        [ActionName("SelectByIdxAgeRating")]
        public AgeRating? GetById(int id) => AgeRatingDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertAgeRating")]
        public int Insert([FromBody] AgeRating AR)
        {
            var db = new  AgeRatingDB();
            db.Insert(AR);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateAgeRating")]
        public int Update([FromBody] AgeRating AR)
        {
            var db = new AgeRatingDB();
            db.Update(AR);
            return db.SaveChanges();
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteCity")]
        public int Delete(int id)
        {
            var c = AgeRatingDB.SelectById(id);
            if (c == null) return 0;
            var db = new AgeRatingDB();
            db.Delete(c);
            return db.SaveChanges();
        }
    }
}
