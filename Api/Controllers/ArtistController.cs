using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

[ApiController]
[Route("api/[controller]/[action]")]
public class ArtistController : ControllerBase
{
    [HttpGet]
    public ArtistList GetAll() => new ArtistDB().SelectAll();

    [HttpGet("{id}")]
    public Artist? GetById(int id) => ArtistDB.SelectById(id);

    [HttpPost]
    public int Insert([FromBody] Artist a)
    {
        var db = new ArtistDB();
        db.Insert(a);
        return db.SaveChanges();
    }

    [HttpPut]
    public int Update([FromBody] Artist a)
    {
        var db = new ArtistDB();
        db.Update(a);
        return db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        var a = ArtistDB.SelectById(id);
        if (a == null) return 0;
        var db = new ArtistDB();
        db.Delete(a);
        return db.SaveChanges();
    }
}
