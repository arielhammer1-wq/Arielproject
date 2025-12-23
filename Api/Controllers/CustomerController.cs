using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public CustomerList GetAll() => new CustomerDB().SelectAll();

    [HttpGet("{id}")]
    public Customer? GetById(int id) => CustomerDB.SelectById(id);

    [HttpPost]
    public int Insert([FromBody] Customer c)
    {
        var db = new CustomerDB();
        db.Insert(c);
        return db.SaveChanges();
    }

    [HttpPut]
    public int Update([FromBody] Customer c)
    {
        var db = new CustomerDB();
        db.Update(c);
        return db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        var c = CustomerDB.SelectById(id);
        if (c == null) return 0;
        var db = new CustomerDB();
        db.Delete(c);
        return db.SaveChanges();
    }
}
