using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

[ApiController]
[Route("api/[controller]/[action]")]
public class GenresinMoviesController : ControllerBase
{
    [HttpGet]
    public GenresinMoviesList GetAll() => new GenresInMoviesDB().SelectAll();

    [HttpGet("{id}")]
    public GenresinMovies? GetById(int id) => GenresInMoviesDB.SelectById(id);

    [HttpPost]
    public int Insert([FromBody] GenresinMovies gm)
    {
        var db = new GenresInMoviesDB();
        db.Insert(gm);
        return db.SaveChanges();
    }

    [HttpPut]
    public int Update([FromBody] GenresinMovies gm)
    {
        var db = new GenresInMoviesDB();
        db.Update(gm);
        return db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        var gm = GenresInMoviesDB.SelectById(id);
        if (gm == null) return 0;
        var db = new GenresInMoviesDB();
        db.Delete(gm);
        return db.SaveChanges();
    }
}
