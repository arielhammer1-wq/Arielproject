using Model;
using ViewModel;
namespace Test
{
    internal class Program
    {
         static void Main(string[] args)
        {
            //// 🔹 City
            //CityDB cdb = new();
            //CityList cList = cdb.SelectAll();
            //Console.WriteLine("Cities found: " + cList.Count);
            //foreach (City c in cList)
            //    Console.WriteLine(c.CityName);
            //Console.WriteLine(new string('-', 40));

            // 🔹 Movie
            //MovieDB mdb = new();
            //MovieList mList = mdb.SelectAll();
            //Console.WriteLine("Movies found: " + mList.Count);
            //foreach (Movie m in mList)
            //    Console.WriteLine($"{m.Id}: {m.MovieName}");
            //Console.WriteLine(new string('-', 40));

            //// 🔹 Actor
            ActorsInMovieDB adb = new();
            ActorsInMovieList aList = adb.SelectAll();
            Console.WriteLine("Actors found: " + aList.Count);
            foreach (ActorsInMovie a in aList)
                Console.WriteLine($"{a.Id}: {a.Artist.ArtistName}");
            Console.WriteLine(new string('-', 40));

            //// 🔹 ActorsInMovie
            //ActorsInMovieDB aimdb = new();
            //ActorsInMovieList aimList = aimdb.SelectAll();
            //Console.WriteLine("ActorsInMovie records found: " + aimList.Count);
            //foreach (ActorsInMovie aim in aimList)
            //    Console.WriteLine($"MovieId: {aim.Movie}, ActorId: {aim.Artist}");
            //Console.WriteLine(new string('-', 40));

            //// 🔹 Theater
            //TheaterDB tdb = new();
            //TheaterList tList = tdb.SelectAll();
            //Console.WriteLine("Theaters found: " + tList.Count);
            //foreach (Theater t in tList)
            //    Console.WriteLine($"{t.Id}: {t.NameOfTheater}");
            //Console.WriteLine(new string('-', 40));

            ////// 🔹 Screening
            ////MovieScreening sdb = new();
            ////MovieScreening sList = sdb.SelectAll();
            ////Console.WriteLine("Screenings found: " + sList.Count);
            ////foreach (MovieScreening s in sList)
            ////    Console.WriteLine($"MovieId: {s.Movie}, TheaterId: {s.Id}, Time: {s.TimeOfScreening}");
            ////Console.WriteLine(new string('-', 40));

            //// 🔹 Ticket
            //TicketDB tkdb = new();
            //TicketList tkList = tkdb.SelectAll();
            //Console.WriteLine("Tickets found: " + tkList.Count);
            //foreach (Ticket tk in tkList)
            //    Console.WriteLine($"TicketId: {tk.Id}, ScreeningId: {tk.Screening}, Price: {tk.TicketPrice}");
            //Console.WriteLine(new string('-', 40));

            //// 🔹 Customer
            //CustomerDB cudb = new();
            //CustomerList cuList = cudb.SelectAll();
            //Console.WriteLine("Customers found: " + cuList.Count);
            //foreach (Customer cu in cuList)
            //    Console.WriteLine($"{cu.Id}: {cu.Username}");
            //Console.WriteLine(new string('-', 40));

            Console.WriteLine("✅ All DB tests finished.");
            Console.ReadLine();
        }
    }
}
