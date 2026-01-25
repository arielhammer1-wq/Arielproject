using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllUsers")]
        public UserList GetAll() => new UserDB().SelectAll();

        [HttpGet]
        [ActionName("SelectByIdxUser{id}")]
        public User? GetById(int id) => UserDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertUser")]
        public int Insert([FromBody] User u)
        {
            var db = new UserDB();
            db.Insert(u);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateUser")]
        public int Update([FromBody] User u)
        {
            var db = new UserDB();
            db.Update(u);
            return db.SaveChanges();
        }


        [HttpDelete]
        [ActionName("DeleteUser{id}")]
        public int Delete(int id)
        {
            var u = UserDB.SelectById(id);
            if (u == null) return 0;
            var db = new UserDB();
            db.Delete(u);
            return db.SaveChanges();
        }
    }
}
