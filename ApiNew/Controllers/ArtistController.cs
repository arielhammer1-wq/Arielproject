using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ArtistController : ControllerBase
    {
        [HttpGet("SelectAllArtists")]
        public ArtistList GetAll() => new ArtistDB().SelectAll();

        [HttpGet("SelectByIdxArtist{id}")]
        public Artist? GetById(int id) => ArtistDB.SelectById(id);

        [HttpPost("InsertArtist")]
        public int Insert([FromBody] Artist a)
        {
            var db = new ArtistDB();
            db.Insert(a);
            return db.SaveChanges();
        }

        [HttpPut("UpdateArtist")]
        public int Update([FromBody] Artist a)
        {
            var db = new ArtistDB();
            db.Update(a);
            return db.SaveChanges();
        }

        [HttpDelete("DeleteArtist{id}")]
        public int Delete(int id)
        {
            var a = ArtistDB.SelectById(id);
            if (a == null) return 0;
            var db = new ArtistDB();
            db.Delete(a);
            return db.SaveChanges();
        }
    }
}
