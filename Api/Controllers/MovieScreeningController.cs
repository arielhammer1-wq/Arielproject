using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;


namespace Arielprojectapi.Contrllers
{
[ApiController]
[Route("api/[controller]/[action]")]
public class MovieScreeningController : ControllerBase
{

    [HttpGet]
    public MovieScreeningList GetAll() => new MovieScreeningDB().SelectAll();

    [HttpGet("{id}")]
    public MovieScreening? GetById(int id) => MovieScreeningDB.SelectById(id);

    [HttpPost]
    public int Insert([FromBody] MovieScreening ms)
    {
        var db = new MovieScreeningDB();
        db.Insert(ms);
        return db.SaveChanges();
    }

    [HttpPut]
    public int Update([FromBody] MovieScreening ms)
    {
        var db = new MovieScreeningDB();
        db.Update(ms);
        return db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        var ms = MovieScreeningDB.SelectById(id);
        if (ms == null) return 0;
        var db = new MovieScreeningDB();
        db.Delete(ms);
        return db.SaveChanges();
    }
}
}