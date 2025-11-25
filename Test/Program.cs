using Model;
using ViewModel;
namespace Test
{
    internal class Program
    {
         static void Main(string[] args)
        {
            ////// 🔹 City
            //CityDB cdb = new();
            //CityList cList = cdb.SelectAll();
            //Console.WriteLine("Cities found: " + cList.Count);
            //foreach (City c in cList)
            //    Console.WriteLine(c.CityName);
            //City cityToUpdate = cList[0];
            //cityToUpdate.CityName = "omerland";
            //cdb.Update(cityToUpdate);
            //int x = cdb.SaveChanges();
            //Console.WriteLine($"{x} rows were updated");
            //Console.WriteLine(new string('-', 40));


            ////// 🔹 Movie
            //MovieDB mdb = new();
            //MovieList mList = mdb.SelectAll();
            //Console.WriteLine("Movies found: " + mList.Count);

            //foreach (Movie m in mList)
            //    Console.WriteLine($"{m.Id}: {m.MovieName}, {m.MovieLength}, {m.AgeRatingName}, {m.ReleaseDate}, {m.Genre}");

            //Movie movieToUpdate = mList[0];

            //movieToUpdate.MovieName = "Peter Pan";
            //movieToUpdate.MovieLength = 120;
            //movieToUpdate.AgeRatingName = AgeRatingDB.SelectById(2);
            //movieToUpdate.ReleaseDate = new DateTime(2024, 1, 1);
            //movieToUpdate.Genre = MovieGenreDB.SelectById(3);

            //mdb.Update(movieToUpdate);
            //int x = mdb.SaveChanges();
            //Console.WriteLine($"{x} rows were updated");

            //Console.WriteLine(new string('-', 40));

            //////// 🔹 Actor
            //ActorsInMovieDB adb = new();
            //ActorsInMovieList aList = adb.SelectAll();
            //Console.WriteLine("Actors found: " + aList.Count);
            //foreach (ActorsInMovie a in aList)
            //    Console.WriteLine($"{a.Id}: {a.Artist.ArtistName}");
            //Console.WriteLine(new string('-', 40));

            //////// 🔹 ActorsInMovie
            //ActorsInMovieDB aimdb = new();
            //ActorsInMovieList aimList = aimdb.SelectAll();
            //Console.WriteLine("ActorsInMovie records found: " + aimList.Count);
            //foreach (ActorsInMovie aim in aimList)
            //    Console.WriteLine($"MovieId: {aim.Movie}, ActorId: {aim.Artist}");
            //Console.WriteLine(new string('-', 40));

            ////// 🔹 Theater
            //TheaterDB tdb = new();
            //TheaterList tList = tdb.SelectAll();
            //Console.WriteLine("Theaters found: " + tList.Count);
            //foreach (Theater t in tList)
            //    Console.WriteLine($"{t.Id}: {t.NameOfTheater}");
            //Console.WriteLine(new string('-', 40));

            //////// 🔹 Screening
            //MovieScreeningDB msdb = new();
            //MovieScreeningList msList = msdb.SelectAll();

            //Console.WriteLine("Screenings found: " + msList.Count);
            //foreach (MovieScreening ms in msList)
            //    Console.WriteLine($"ScreeningId: {ms.Id}, MovieId: {ms.MovieScreened.Id}, HallId: {ms.HallId.Id}, Time: {ms.TimeOfScreening}");

            //MovieScreening movieScreeningToUpdate = msList[0]; // first screening

            //movieScreeningToUpdate.HallId = MovieHallDB.SelectById(3);
            //movieScreeningToUpdate.TimeOfScreening = new DateTime(2024, 2, 1);
            //movieScreeningToUpdate.MovieScreened = MovieDB.SelectById(3);

            //msdb.Update(movieScreeningToUpdate);
            //int x = msdb.SaveChanges();

            //Console.WriteLine($"{x} rows were updated");


            //////// 🔹 Ticket
            //TicketDB tkdb = new();
            //TicketList tkList = tkdb.SelectAll();
            //Console.WriteLine("Tickets found: " + tkList.Count);
            //foreach (Ticket tk in tkList)
            //    Console.WriteLine($"TicketId: {tk.Id}, ScreeningId: {tk.Screening.Id}, Price: {tk.TicketPrice},UserId: { tk.User.Id}");
            //Ticket TicketToUpdate = tkList[0]; // first screening

            //TicketToUpdate.TicketPrice = 100;
            //TicketToUpdate.User = UserDB.SelectById(3);
            //TicketToUpdate.Screening = MovieScreeningDB.SelectById(3);

            //tkdb.Update(TicketToUpdate);
            //int x = tkdb.SaveChanges();
            //Console.WriteLine($"{x} rows were updated");
            //Console.WriteLine(new string('-', 40));

            //////// 🔹 Customer
            CustomerDB cudb = new();
            CustomerList cuList = cudb.SelectAll();
            Console.WriteLine("Customers found: " + cuList.Count);
            foreach (Customer cu in cuList)
                Console.WriteLine($"customer id is {cu.Id}: {cu.Username},{cu.CustomerGender}");
            Customer CustomerToUpdate = cuList[0];

            CustomerToUpdate.DateOfBirth = new DateTime(2024, 2, 1);
            CustomerToUpdate.CustomerGender = GenderDB.SelectById(1);
            CustomerToUpdate.RepeatCustomer = true;

            cudb.Update(CustomerToUpdate);
            int x = cudb.SaveChanges();
            Console.WriteLine($"{x} rows were updated");
            Console.WriteLine(new string('-', 40));

            //MovieGenreDB mgdb = new();
            //MovieGenreList mgList = mgdb.SelectAll();
            //Console.WriteLine("Movies found: " + mgList.Count);
            //foreach (MovieGenre mg in mgList)
            //    Console.WriteLine($"{mg.Id}: {mg.Id},{mg.GenreName}");
            //MovieGenre MovieGenreToUpdate = mgList[0];
            //MovieGenreToUpdate.GenreName = "Family";
            //mgdb.Update(MovieGenreToUpdate);
            //int x = mgdb.SaveChanges();
            //Console.WriteLine($"{x} rows were updated");
            //Console.WriteLine(new string('-', 40));

            //Console.WriteLine("✅ All DB tests finished.");
            //Console.ReadLine();




        }
    }
}
