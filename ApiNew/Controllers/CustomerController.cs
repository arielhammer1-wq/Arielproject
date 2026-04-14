using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Removed /[action] to make routes cleaner
    public class CustomerController : ControllerBase
    {
        // URL: api/Customer/SelectAllCustomers
        [HttpGet("SelectAllCustomers")]
        public CustomerList GetAll() => new CustomerDB().SelectAll();

        // URL: api/Customer/SelectByIdxCustomer/5
        [HttpGet("SelectByIdxCustomer/{id}")]
        public Customer? GetById(int id) => CustomerDB.SelectById(id);

        // URL: api/Customer/InsertCustomer
        [HttpPost("InsertCustomer")]
        public int Insert([FromBody] Customer c)
        {
            var db = new CustomerDB();
            db.Insert(c);
            return db.SaveChanges();
        }

        // URL: api/Customer/UpdateCustomer
        [HttpPut("UpdateCustomer")]
        public int Update([FromBody] Customer c)
        {
            var db = new CustomerDB();
            db.Update(c);
            return db.SaveChanges();
        }

        // URL: api/Customer/DeleteCustomer/5
        [HttpDelete("DeleteCustomer/{id}")]
        public int Delete(int id)
        {
            var c = CustomerDB.SelectById(id);
            if (c == null) return 0;
            var db = new CustomerDB();
            db.Delete(c);
            return db.SaveChanges();
        }
    }
}