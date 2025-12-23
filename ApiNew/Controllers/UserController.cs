//using Microsoft.AspNetCore.Mvc;
//using Model;
//using ViewModel;

//namespace ApiNew.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]/[action]")]
//    public class UserController : ControllerBase
//    {
//        [HttpGet("SelectAllUsers")]
//        public UserList GetAll() => new UsersDB().SelectAll();

//        [HttpGet("SelectByIdxUser{id}")]
//        public User? GetById(int id) => UsersDB.SelectById(id);

//        [HttpPost("InsertUser")]
//        public int Insert([FromBody] User u)
//        {
//            var db = new UsersDB();
//            db.Insert(u);
//            return db.SaveChanges();
//        }

//        [HttpPut("UpdateUser")]
//        public int Update([FromBody] User u)
//        {
//            var db = new UsersDB();
//            db.Update(u);
//            return db.SaveChanges();
//        }


//        [HttpDelete("DeleteUser{id}")]
//        public int Delete(int id)
//        {
//            var u = UsersDB.SelectById(id);
//            if (u == null) return 0;
//            var db = new UsersDB();
//            db.Delete(u);
//            return db.SaveChanges();
//        }
//    }
//}
