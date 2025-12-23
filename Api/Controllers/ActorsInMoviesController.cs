using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

[ApiController]
[Route("api/[controller]/[action]")]
public class ActorsInMovieController : ControllerBase
{
    [HttpGet]
    public ActorsInMovieList GetAll() => new ActorsInMovieDB().SelectAll();

    [HttpGet("{id}")]
    public ActorsInMovie? GetById(int id) => ActorsInMovieDB.SelectById(id);

    [HttpPost]
    public int Insert([FromBody] ActorsInMovie ai)
    {
        var db = new ActorsInMovieDB();
        db.Insert(ai);
        return db.SaveChanges();
    }

    [HttpPut]
    public int Update([FromBody] ActorsInMovie ai)
    {
        var db = new ActorsInMovieDB();
        db.Update(ai);
        return db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        var ai = ActorsInMovieDB.SelectById(id);
        if (ai == null) return 0;
        var db = new ActorsInMovieDB();
        db.Delete(ai);
        return db.SaveChanges();
    }
}
