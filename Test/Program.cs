using Model;
using ViewModel;
namespace Test
{
    internal class Program
    {
         static void Main(string[] args)
        {
            //// 🔹 City
            //Console.WriteLine("City:");

            //CityDB cdb = new CityDB();
            //CityList cList = cdb.SelectAll();

            //foreach (City c in cList)
            //    Console.WriteLine($"{c.Id}: {c.CityName}");
            //Console.WriteLine();

            //City cInsert = new City();
            //cInsert.CityName = "NewCityLand";
            //cdb.Insert(cInsert);

            //int x = cdb.SaveChanges();
            //Console.WriteLine($"{x} rows were inserted");

            //foreach (City c in cList)
            //    Console.WriteLine($"{c.Id}: {c.CityName}");
            //Console.WriteLine();


            //City cityToUpdate = cList.Last();
            //cityToUpdate.CityName = "UpdatedCity";
            //cdb.Update(cityToUpdate);

            //int y = cdb.SaveChanges();
            //Console.WriteLine($"{y} rows were updated");

            //foreach (City c in cList)
            //    Console.WriteLine($"{c.Id}: {c.CityName}");
            //Console.WriteLine();


            //City cityToDelete = cList.Last();
            //cdb.Delete(cityToDelete);

            //int z = cdb.SaveChanges();
            //Console.WriteLine($"{z} rows were deleted");

            //foreach (City c in cList)
            //    Console.WriteLine($"{c.Id}: {c.CityName}");
            //Console.WriteLine();


            //🔹 User
            //UserDB udb = new();
            //UserList uList = udb.SelectAll();
            //Console.WriteLine("users found " + uList.Count);
            //foreach (User u in uList)
            //    Console.WriteLine($"{u.Id}: {u.Username}, {u.Pass}, {u.Email}");

            //User UserToUpdate = uList[0];
            //UserToUpdate.Username = "Arielbomboclat";
            //udb.Update(UserToUpdate);
            //int temp = udb.SaveChanges();
            //Console.WriteLine($"{temp} rows were updated");
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


            //////// 🔹 ActorsinMovie
            Console.WriteLine("ActorsInMovie:");

            ActorsInMovieDB aimdb = new ActorsInMovieDB();
            ActorsInMovieList aimList = aimdb.SelectAll();

            foreach (ActorsInMovie aim in aimList)
                Console.WriteLine($"MovieId: {aim.M.Id}, ActorId: {aim.A.Id}");
            Console.WriteLine();


            // 🔹 Insert
            //ActorsInMovie aimInsert = new ActorsInMovie();
            //aimInsert.M = MovieDB.SelectById(1);      // example movie
            //aimInsert.A = ArtistDB.SelectById(1);    // example actor
            //aimdb.Insert(aimInsert);

            //int x = aimdb.SaveChanges();
            //Console.WriteLine($"{x} rows were inserted");

            //foreach (ActorsInMovie aim in aimList)
            //    Console.WriteLine($"MovieId: {aim.M.Id}, ActorId: {aim.A.Id}");
            //Console.WriteLine();


            // 🔹 Update(change the actor for the last movie - actor link)
            //ActorsInMovie aimUpdate = aimList.Last();
            //aimUpdate.M = MovieDB.SelectById(1);
            //aimUpdate.A = ArtistDB.SelectById(7);    // new actor
            //aimdb.Update(aimUpdate);

            //int k = aimdb.SaveChanges();
            //Console.WriteLine($"{k} rows were updated");

            //foreach (ActorsInMovie aim in aimList)
            //    Console.WriteLine($"MovieId: {aim.M.Id}, ActorId: {aim.A.Id}");
            //Console.WriteLine();


            //🔹 Delete
            //ActorsInMovie aimDelete = aimList.Last();
            //aimdb.Delete(aimDelete);

            //int z = aimdb.SaveChanges();
            //Console.WriteLine($"{z} rows were deleted");

            //foreach (ActorsInMovie aim in aimList)
            //    Console.WriteLine($"MovieId: {aim.M.Id}, ActorId: {aim.A.Id}");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();


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
            //CustomerDB cudb = new();
            //CustomerList cuList = cudb.SelectAll();
            //Console.WriteLine("Customers found: " + cuList.Count);
            //foreach (Customer cu in cuList)
            //    Console.WriteLine($"customer id is {cu.Id}: {cu.Username},{cu.CustomerGender.GenderName}, is a Repeat Customer?  {cu.RepeatCustomer}");
            //Customer CustomerToUpdate = cuList[0];

            //CustomerToUpdate.DateOfBirth = new DateTime(2024, 2, 1);
            //CustomerToUpdate.CustomerGender = GenderDB.SelectById(1);
            //CustomerToUpdate.RepeatCustomer = true;

            //cudb.Update(CustomerToUpdate);
            //int customerC = cudb.SaveChanges();
            //Console.WriteLine($"{customerC} rows were updated");
            //Console.WriteLine(new string('-', 40));

            //////// 🔹 Artist
            //ArtistDB Adb = new();
            //ArtistList AList = Adb.SelectAll();
            //Console.WriteLine("Artists found: " + AList.Count);
            //foreach (Artist artist in AList)
            //    Console.WriteLine($"Artist id is {artist.Id}: {artist.ArtistName},{artist.StartingYear}{artist.ArtistRole}");
            //Artist ArtistToUpdate = AList[0];

            //ArtistToUpdate.ArtistName = "Pdidi";
            //ArtistToUpdate.StartingYear = 2025;
            //ArtistToUpdate.ArtistRole = RoleDB.SelectById(1);

            //Adb.Update(ArtistToUpdate);
            //int ArtistC = Adb.SaveChanges();
            //Console.WriteLine($"{ArtistC} rows were updated");
            //Console.WriteLine(new string('-', 40));

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
