//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using Model;
//using ViewModel;

//[ApiController]
//[Route("api/[controller]/[action]")]
//public class UserController : ControllerBase
//{
//    [HttpGet]
//    public UserList GetAll() => new UsersDB().SelectAll();

//    [HttpGet("{id}")]
//    public User? GetById(int id) => UsersDB.SelectById(id);

//    [HttpPost]
//    public int Insert([FromBody] User u)
//    {
//        var db = new UsersDB();
//        db.Insert(u);
//        return db.SaveChanges();
//    }

//    [HttpPut]
//    public int Update([FromBody] User u)
//    {
//        var db = new UsersDB();
//        db.Update(u);
//        return db.SaveChanges();
//    }

//    [HttpDelete("{id}")]
//    public int Delete(int id)
//    {
//        var u = UsersDB.SelectById(id);
//        if (u == null) return 0;
//        var db = new UsersDB();
//        db.Delete(u);
//        return db.SaveChanges();
//    }
//}