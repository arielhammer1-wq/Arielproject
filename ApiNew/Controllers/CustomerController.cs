using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllCustomers")]
        public CustomerList GetAll() => new CustomerDB().SelectAll();
        [HttpGet]
        [ActionName("SelectByIdxCustomer{id}")]
        public Customer? GetById(int id) => CustomerDB.SelectById(id);

        [HttpPost]
        [ActionName("InsertCustomer")]
        public int Insert([FromBody] Customer c)
        {
            var db = new CustomerDB();
            db.Insert(c);
            return db.SaveChanges();
        }

        [HttpPut]
        [ActionName("UpdateCustomer")]
        public int Update([FromBody] Customer c)
        {
            var db = new CustomerDB();
            db.Update(c);
            return db.SaveChanges();
        }


        [HttpDelete]
        [ActionName("DeleteCustomer{id}")]
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
