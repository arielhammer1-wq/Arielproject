using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TicketController : ControllerBase
    {
        [HttpGet]
        public TicketList GetAll() => new TicketDB().SelectAll();

        [HttpGet("{id}")]
        public Ticket? GetById(int id) => TicketDB.SelectById(id);

        [HttpPost]
        public int Insert([FromBody] Ticket t)
        {
            var db = new TicketDB();
            db.Insert(t);
            return db.SaveChanges();
        }

        [HttpPut]
        public int Update([FromBody] Ticket t)
        {
            var db = new TicketDB();
            db.Update(t);
            return db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var t = TicketDB.SelectById(id);
            if (t == null) return 0;
            var db = new TicketDB();
            db.Delete(t);
            return db.SaveChanges();
        }
    }
}
