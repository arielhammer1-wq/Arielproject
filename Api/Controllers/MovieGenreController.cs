using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

[ApiController]
[Route("api/[controller]/[action]")]
public class MovieGenreController : ControllerBase
{
    [HttpGet]
    public MovieGenreList GetAll() => new MovieGenreDB().SelectAll();

    [HttpGet("{id}")]
    public MovieGenre? GetById(int id) => MovieGenreDB.SelectById(id);

    [HttpPost]
    public int Insert([FromBody] MovieGenre g)
    {
        var db = new MovieGenreDB();
        db.Insert(g);
        return db.SaveChanges();
    }

    [HttpPut]
    public int Update([FromBody] MovieGenre g)
    {
        var db = new MovieGenreDB();
        db.Update(g);
        return db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        var g = MovieGenreDB.SelectById(id);
        if (g == null) return 0;
        var db = new MovieGenreDB();
        db.Delete(g);
        return db.SaveChanges();
    }
}
