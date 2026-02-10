using System;
using System.Linq;
using Model;
using ViewModel;

namespace Test
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            TicketVmTest.Run();

            Console.WriteLine("\nDONE. Press any key...");
            Console.ReadKey();
        }
    }

    public class TicketVmTest
    {
        public static void Run()
        {
            TicketDB tdb = new TicketDB();

            // ---------- USER ----------
            User user = UserDB.SelectById(1);
            if (user == null)
            {
                Console.WriteLine("❌ User with Id=1 not found");
                return;
            }

            Console.WriteLine("=== TICKET TEST ===");

            // ---------- INSERT ----------
            Ticket ticket = new Ticket
            {
                SeatNumber = 5,
                TicketPrice = 40,
                User = user,    
                Movie = MovieDB.SelectById(1),       // ⚠️ ID שקיים באמת
                Theater = TheaterDB.SelectById(1),   // ⚠️
                Hall = MovieHallDB.SelectById(1)
            };

            tdb.Insert(ticket);
            int inserted = tdb.SaveChanges();
            Console.WriteLine($"Inserted: {inserted}");

            if (inserted == 0)
            {
                Console.WriteLine("❌ Insert failed");
                return;
            }

            // ---------- SELECT ----------
            TicketList tickets = tdb.SelectAll();
            PrintTickets(tickets);

            if (tickets.Count == 0)
            {
                Console.WriteLine("❌ No tickets found after insert");
                return;
            }

            // ---------- UPDATE ----------
            Ticket ticketToUpdate = tickets.Last();
            ticketToUpdate.SeatNumber = 8;
            ticketToUpdate.TicketPrice = 45;

            tdb.Update(ticketToUpdate);
            Console.WriteLine($"Updated: {tdb.SaveChanges()}");

            tickets = tdb.SelectAll();
            PrintTickets(tickets);

            // ---------- DELETE ----------
            Ticket ticketToDelete = tickets.Last();
            tdb.Delete(ticketToDelete);
            Console.WriteLine($"Deleted: {tdb.SaveChanges()}");

            tickets = tdb.SelectAll();
            PrintTickets(tickets);

            Console.WriteLine("=== TICKET TEST DONE ===");
        }

        private static void PrintTickets(TicketList tickets)
        {
            foreach (Ticket t in tickets)
            {
                Console.WriteLine(
                    $"Id:{t.Id}, Seat:{t.SeatNumber}, Price:{t.TicketPrice}, User:{t.User?.Username}"
                );
            }
            Console.WriteLine();
        }
    }
}
