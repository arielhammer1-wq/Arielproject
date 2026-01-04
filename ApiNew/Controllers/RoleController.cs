using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

[ApiController]
[Route("api/[controller]/[action]")]
public class RoleController : ControllerBase
{
    [HttpGet]
    [ActionName("SelectAllRoles")]
    public RoleList GetAll() => new RoleDB().SelectAll();

    [HttpGet]
    [ActionName("SelectByIdxRole{id}")] 
    public Role? GetById(int id) => RoleDB.SelectById(id);

     [HttpPost]
    [ActionName("InsertRole")]
    public int Insert([FromBody] Role r)
    {
        var db = new RoleDB();
        db.Insert(r);
        return db.SaveChanges();
    }

    [HttpPut]
    [ActionName("UpdateRole")]
    public int Update([FromBody] Role r)
    {
        var db = new RoleDB();
        db.Update(r);
        return db.SaveChanges();
    }

    [HttpDelete]
    [ActionName("DeleteRole{id}")]
    public int Delete(int id)
    {
        var r = RoleDB.SelectById(id);
        if (r == null) return 0;
        var db = new RoleDB();
        db.Delete(r);
        return db.SaveChanges();
    }
}
