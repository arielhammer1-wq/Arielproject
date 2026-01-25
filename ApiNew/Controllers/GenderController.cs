using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GenderController : ControllerBase
    {
        // GET: api/Gender/SelectAllGenders
        [HttpGet]
        [ActionName("SelectAllGenders")]
        public GenderList GetAll()
        {
            return new GenderDB().SelectAll();
        }

        // GET: api/Gender/SelectByIdGender?id=1
        [HttpGet]
        [ActionName("SelectByIdGender")]
        public Gender? GetById(int id)
        {
            return GenderDB.SelectById(id);
        }

        // POST: api/Gender/InsertGender
        [HttpPost]
        [ActionName("InsertGender")]
        public int Insert([FromBody] Gender g)
        {
            var db = new GenderDB();
            db.Insert(g);
            return db.SaveChanges();
        }

        // PUT: api/Gender/UpdateGender
        [HttpPut]
        [ActionName("UpdateGender")]
        public int Update([FromBody] Gender g)
        {
            var db = new GenderDB();
            db.Update(g);
            return db.SaveChanges();
        }

        // DELETE: api/Gender/DeleteGender/1
        [HttpDelete("{id}")]
        [ActionName("DeleteGender")]
        public int Delete(int id)
        {
            var g = GenderDB.SelectById(id);
            if (g == null) return 0;

            var db = new GenderDB();
            db.Delete(g);
            return db.SaveChanges();
        }
    }
}
