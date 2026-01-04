using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

[ApiController]
[Route("api/[controller]/[action]")]
public class OperatorController : ControllerBase
{
    [HttpGet]
    [ActionName("SelectAllOperators")] 
    public OperatorList GetAll() => new OperatorDB().SelectAll();

    [HttpGet]
    [ActionName("SelectByIdxOperator{id}")]
    public Operator? GetById(int id) => (Operator)OperatorDB.SelectById(id);

    [HttpPost]
    [ActionName("InsertOperator")]
    public int Insert([FromBody] Operator o)
    {
        var db = new OperatorDB();
        db.Insert(o);
        return db.SaveChanges();
    }


    [HttpPut]
    [ActionName("UpdateOperator")]
    public int Update([FromBody] Operator o)
    {
        var db = new OperatorDB();
        db.Update(o);
        return db.SaveChanges();
    }

    [HttpDelete]
    [ActionName("DeleteOperator{id}")]
    public int Delete(int id)
    {
        var o = OperatorDB.SelectById(id);
        if (o == null) return 0;
        var db = new OperatorDB();
        db.Delete(o);
        return db.SaveChanges();
    }
}
