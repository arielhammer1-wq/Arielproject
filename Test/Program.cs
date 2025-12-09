using Model;
using ViewModel;
using ViewModel.ViewModel;
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperatorDB odb = new OperatorDB();

            //
            // INSERT
            //
            Operator newOp = new Operator
            {
                Username = "Operator1",
                Pass = "1234",
                Email = "op1@mail.com",
                RoleName = RoleDB.SelectById(1)  // make sure role exists
            };

            odb.Insert(newOp);
            int inserted = odb.SaveChanges();
            Console.WriteLine($"{inserted} row(s) inserted.");

            //
            // UPDATE
            //
            OperatorList temp = odb.SelectAll();
            Operator toUpdate = temp[0];

            toUpdate.Email = "updated@mail.com";
            toUpdate.RoleName = RoleDB.SelectById(2);

            odb.Update(toUpdate);
            int updated = odb.SaveChanges();
            Console.WriteLine($"{updated} row(s) updated.");

            //
            // DELETE
            //
            temp = odb.SelectAll();
            Operator toDelete = temp[temp.Count - 1];

            odb.Delete(toDelete);
            int deleted = odb.SaveChanges();
            Console.WriteLine($"{deleted} row(s) deleted.");

            //
            // FINAL REFRESH
            //
            Console.WriteLine("\n=== FINAL OPERATORS LIST ===");
            OperatorList final = odb.SelectAll();

            foreach (Operator op in final)
            {
                Console.WriteLine(
                    $"Id: {op.Id}, User={op.Username}, Email={op.Email}, Role={op.RoleName.RoleName}"
                );
            }

            //    GenresInMoviesDB gmdb = new GenresInMoviesDB();

            //    //
            //    // INSERT
            //    //
            //    GenresinMovies newGM = new GenresinMovies
            //    {
            //        MG = MovieGenreDB.SelectById(1),  // Ensure Genre with Id=1 exists
            //        M = MovieDB.SelectById(1)         // Ensure Movie with Id=1 exists
            //    };

            //    gmdb.Insert(newGM);
            //    int inserted = gmdb.SaveChanges();
            //    Console.WriteLine($"{inserted} row(s) inserted.");

            //    //
            //    // UPDATE
            //    //
            //    GenresinMoviesList temp = gmdb.SelectAll();
            //    GenresinMovies toUpdate = temp[1];

            //    toUpdate.MG = MovieGenreDB.SelectById(2);  // change genre
            //    toUpdate.M = MovieDB.SelectById(2);       // change movie

            //    gmdb.Update(toUpdate);
            //    int updated = gmdb.SaveChanges();
            //    Console.WriteLine($"{updated} row(s) updated.");

            //    //
            //    // DELETE
            //    //
            //    temp = gmdb.SelectAll();
            //    GenresinMovies toDelete = temp[temp.Count - 1];

            //    gmdb.Delete(toDelete);
            //    int deleted = gmdb.SaveChanges();
            //    Console.WriteLine($"{deleted} row(s) deleted.");

            //    //
            //    // FINAL REFRESH
            //    //
            //    Console.WriteLine("\n=== FINAL GENRES-IN-MOVIES LIST ===");
            //    GenresinMoviesList finalList = gmdb.SelectAll();

            //    foreach (GenresinMovies gm in finalList)
            //    {
            //        Console.WriteLine(
            //            $"Id: {gm.Id}, Genre: {gm.MG.GenreName}, Movie: {gm.M.MovieName}"
            //        );
            //    }

            //    Console.WriteLine("\nProgram finished.");
            //}


            //MovieHallDB hdb = new MovieHallDB();

            ////
            //// INSERT
            ////
            //MovieHall newHall = new MovieHall
            //{
            //    HallName = "Hall A",
            //    AmountOfSeats = 200,
            //    Theater = TheaterDB.SelectById(1)   // Make sure Theater with Id=1 exists
            //};

            //hdb.Insert(newHall);
            //int inserted = hdb.SaveChanges();
            //Console.WriteLine($"{inserted} row(s) inserted.");

            ////
            //// UPDATE
            ////
            //MovieHallList temp = hdb.SelectAll();
            //MovieHall toUpdate = temp[0];

            //toUpdate.HallName = "Updated Hall";
            //toUpdate.AmountOfSeats = 250;
            //toUpdate.Theater = TheaterDB.SelectById(2);  // change theater

            //hdb.Update(toUpdate);
            //int updated = hdb.SaveChanges();
            //Console.WriteLine($"{updated} row(s) updated.");

            ////
            //// DELETE
            ////
            ////temp = hdb.SelectAll();
            ////MovieHall toDelete = temp[temp.Count - 1];

            ////hdb.Delete(toDelete);
            ////int deleted = hdb.SaveChanges();
            ////Console.WriteLine($"{deleted} row(s) deleted.");

            ////
            //// FINAL REFRESH
            ////
            //Console.WriteLine("\n=== FINAL MOVIE HALL LIST ===");
            //MovieHallList finalList = hdb.SelectAll();

            //foreach (MovieHall h in finalList)
            //{
            //    Console.WriteLine(
            //        $"Id: {h.Id}, Hall: {h.HallName}, Seats: {h.AmountOfSeats}, TheaterId: {h.Theater.Id}"
            //    );
            //}




            //    CustomerDB cdb = new CustomerDB();

            //    //
            //    // INSERT CUSTOMER
            //    //
            //    Customer newCust = new Customer
            //    {
            //        Username = "Customery",
            //        Pass = "pass123",
            //        Email = "newcustomer@example.com",
            //        DateOfBirth = new DateTime(2000, 1, 15),
            //        CustomerGender = GenderDB.SelectById(1),    
            //        RepeatCustomer = false
            //    };

            //    cdb.Insert(newCust);
            //    int inserted = cdb.SaveChanges();
            //    Console.WriteLine($"{inserted} row(s) inserted.\n");

            //    //
            //    // SELECT ALL (TEMP LIST)
            //    //
            //    //CustomerList temp = cdb.SelectAll();

            //    //if (temp.Count == 0)
            //    //{
            //    //    Console.WriteLine("No customers found. Insert failed?");
            //    //    return;
            //    //}

            //    ////
            //    //// UPDATE CUSTOMER
            //    ////
            //    //Customer toUpdate = temp[0];

            //    //toUpdate.Email = "updatedcustomer@example.com";
            //    //toUpdate.RepeatCustomer = true;
            //    //toUpdate.CustomerGender = GenderDB.SelectById(2);   // changing gender for demonstration

            //    //cdb.Update(toUpdate);
            //    //int updated = cdb.SaveChanges();
            //    //Console.WriteLine($"{updated} row(s) updated.\n");

            //    //
            //    // SELECT ALL (TEMP LIST)
            //    //
            //    //temp = cdb.SelectAll();

            //    //
            //    // DELETE CUSTOMER
            //    //
            //    //Customer toDelete = temp[temp.Count - 1];
            //    //Console.WriteLine($"Deleting Id={toDelete.Id}, Username={toDelete.Username}");

            //    //cdb.Delete(toDelete);
            //    //int deleted = cdb.SaveChanges();
            //    //Console.WriteLine($"{deleted} row(s) deleted.\n");

            //    //
            //    // FINAL REFRESH
            //    //
            //    Console.WriteLine("=== FINAL CUSTOMER LIST ===");
            //    CustomerList finalList = cdb.SelectAll();
            //    PrintCustomers(finalList);
            //}

            //static void PrintCustomers(CustomerList list)
            //{
            //    foreach (Customer c in list)
            //    {
            //        Console.WriteLine(
            //            $"Id: {c.Id}, Username: {c.Username}, Email: {c.Email}, " +
            //            $"DOB: {c.DateOfBirth:d}, Gender: {c.CustomerGender.GenderName}, " +
            //            $"RepeatCustomer: {c.RepeatCustomer}"
            //        );
            //    }
            //    Console.WriteLine("---------------------------------------------");
            //}



            ////// 🔹 City
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
            //    UserDB udb = new UserDB();

            //    // ----------------------------
            //    // 1. INSERT NEW USER
            //    // ----------------------------
            //    Console.WriteLine("Inserting new user...");

            //    User newUser = new User
            //    {
            //        Username = "JohnDoe",
            //        Pass = "12345",
            //        Email = "john@example.com"
            //    };

            //    udb.Insert(newUser);
            //    int inserted = udb.SaveChanges();
            //    Console.WriteLine($"{inserted} row(s) inserted.");

            //    // ----------------------------
            //    // 2. UPDATE FIRST USER
            //    // ----------------------------
            //    Console.WriteLine("Updating first user...");

            //    UserList allUsersTemp = udb.SelectAll(); // temporary list
            //    User userToUpdate = allUsersTemp[0];

            //    userToUpdate.Username = "arielh1";
            //    userToUpdate.Pass = "eran1966";
            //    userToUpdate.Email = "arielhammer1@gmail.com";

            //    udb.Update(userToUpdate);
            //    int updated = udb.SaveChanges();
            //    Console.WriteLine($"{updated} row(s) updated.");

            //    // ----------------------------
            //    // 3. DELETE LAST USER
            //    // ----------------------------
            //    Console.WriteLine("Deleting last user...");

            //    allUsersTemp = udb.SelectAll();
            //    User userToDelete = allUsersTemp[allUsersTemp.Count - 1];

            //    udb.Delete(userToDelete);
            //    int deleted = udb.SaveChanges();
            //    Console.WriteLine($"{deleted} row(s) deleted.");

            //    // ----------------------------
            //    // 4. FINAL REFRESH & PRINT
            //    // ----------------------------
            //    Console.WriteLine("\n=== FINAL USERS AFTER ALL OPERATIONS ===");

            //    UserList finalUsers = udb.SelectAll();
            //    PrintUsers(finalUsers);

            //    Console.WriteLine("Done.");
            //}

            //static void PrintUsers(UserList users)
            //{
            //    Console.WriteLine($"Users count: {users.Count}");
            //    foreach (User u in users)
            //    {
            //        Console.WriteLine($"Id: {u.Id}, Username: {u.Username}, Pass: {u.Pass}, Email: {u.Email}");
            //    }
            //    Console.WriteLine("----------------------------------------");
            //}








            //// 🔹 Movie
            //Console.WriteLine("Movie:");

            //MovieDB Mdb = new MovieDB();
            //MovieList MList = Mdb.SelectAll();

            //foreach (Movie M in MList)
            //    Console.WriteLine($"{M.Id}: {M.MovieName}");
            //Console.WriteLine();

            //Movie MInsert = new Movie()
            //{
            //    MovieName = "how to kill a loving bird",
            //    MovieLength = 180,
            //    AgeRatingName = AgeRatingDB.SelectById(2),
            //    ReleaseDate = new DateTime(2000, 12, 22),
            //    Genre = MovieGenreDB.SelectById(3)
            //};


            //Mdb.Insert(MInsert);

            //int MOV = Mdb.SaveChanges();
            //Console.WriteLine($"{MOV} rows were inserted");

            //foreach (Movie M in MList)
            //    Console.WriteLine($"{M.Id}: {M.MovieName}");
            //Console.WriteLine();


            //Movie MovieToUpdate = MList.Last();
            //MovieToUpdate.MovieName = "Movie updated";
            //Mdb.Update(MovieToUpdate);

            //int y = Mdb.SaveChanges();
            //Console.WriteLine($"{y} rows were updated");

            //foreach (Movie M in MList)
            //    Console.WriteLine($"{M.Id}: {M.MovieName}");
            //Console.WriteLine();

            //Movie MovieDelete = MList.Last();
            //Mdb.Delete(MovieDelete);

            //int z = Mdb.SaveChanges();
            //Console.WriteLine($"{z} rows were deleted");

            //foreach (Movie M in MList)
            //    Console.WriteLine($"MovieId: {M.Id}, MovieName: {M.MovieName}");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //////// 🔹 Actor
            //ActorsInMovieDB adb = new();
            //ActorsInMovieList aList = adb.SelectAll();
            //Console.WriteLine("Actors found: " + aList.Count);
            //foreach (ActorsInMovie a in aList)
            //    Console.WriteLine($"{a.Id}: {a.Artist.ArtistName}");
            //Console.WriteLine(new string('-', 40));







            //////// 🔹 ActorsinMovie
            //Console.WriteLine("ActorsInMovie:");

            //ActorsInMovieDB aimdb = new ActorsInMovieDB();
            //ActorsInMovieList aimList = aimdb.SelectAll();

            //foreach (ActorsInMovie aim in aimList)
            //    Console.WriteLine($"MovieId: {aim.M.Id}, ActorId: {aim.A.Id}");
            //Console.WriteLine();


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


            //🔹 Update(change the actor for the last movie - actor link)
            //    ActorsInMovie aimUpdate = aimList.Last();
            //aimUpdate.M = MovieDB.SelectById(1);
            //aimUpdate.A = ArtistDB.SelectById(7);    // new actor
            //aimdb.Update(aimUpdate);

            //int k = aimdb.SaveChanges();
            //Console.WriteLine($"{k} rows were updated");

            //foreach (ActorsInMovie aim in aimList)
            //    Console.WriteLine($"MovieId: {aim.M.Id}, ActorId: {aim.A.Id}");
            //Console.WriteLine();


            ////🔹 Delete
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
            //TheaterDB tdb = new TheaterDB();

            //
            // INSERT
            //
            //Theater newTheater = new Theater
            //{
            //    NameOfTheater = "Cinema City",
            //    Address = "Main Street",
            //    StreetNumber = 10,
            //    CityCode = CityDB.SelectById(1)  // Make sure City with Id=1 exists
            //};

            //tdb.Insert(newTheater);
            //int inserted = tdb.SaveChanges();
            //Console.WriteLine($"{inserted} row(s) inserted.");

            //
            // UPDATE
            //
            //TheaterList temp = tdb.SelectAll();
            //Theater toUpdate = temp[0];

            //toUpdate.NameOfTheater = "Updated Cinema";
            //toUpdate.StreetNumber = 22;
            //toUpdate.CityCode = CityDB.SelectById(2); // change city for demo

            //tdb.Update(toUpdate);
            //int updated = tdb.SaveChanges();
            //Console.WriteLine($"{updated} row(s) updated.");

            ////
            //// DELETE
            ////
            //temp = tdb.SelectAll();
            //Theater toDelete = temp[temp.Count - 1];

            //tdb.Delete(toDelete);
            //int deleted = tdb.SaveChanges();
            //Console.WriteLine($"{deleted} row(s) deleted.");

            ////
            //// FINAL REFRESH
            ////
            //Console.WriteLine("\n=== FINAL THEATER LIST ===");
            //TheaterList finalList = tdb.SelectAll();

            //foreach (Theater t in finalList)
            //{
            //    Console.WriteLine(
            //        $"Id: {t.Id}, Name: {t.NameOfTheater}, Address: {t.Address} {t.StreetNumber}, City: {t.CityCode.CityName}"
            //    );
            //}

            //Console.WriteLine("\nProgram finished.");
        }






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

        // -------- Ticket SELECT ALL --------
        //TicketDB tkdb = new();
        //TicketList tkList = tkdb.SelectAll();
        //Console.WriteLine("Tickets found: " + tkList.Count);
        //foreach (Ticket tk in tkList)
        //    Console.WriteLine($"TicketId: {tk.Id}, ScreeningId: {tk.Screening.Id}, Price: {tk.TicketPrice}, UserId: {tk.User.Id}");

        //Console.WriteLine(new string('-', 40));

        //// -------- INSERT --------
        //Console.WriteLine("Inserting new Ticket...");

        //Ticket newTicket = new Ticket();
        //newTicket.TicketPrice = 42;
        //newTicket.User = UserDB.SelectById(3);
        //newTicket.Screening = MovieScreeningDB.SelectById(3);


        //tkdb.Insert(newTicket);
        //int inserted = tkdb.SaveChanges();

        //Console.WriteLine($"{inserted} rows were inserted");
        //Console.WriteLine(new string('-', 40));

        //// -------- UPDATE --------
        //Console.WriteLine("Updating first ticket...");

        //Ticket TicketToUpdate = tkList[0];

        //TicketToUpdate.TicketPrice = 500;
        //TicketToUpdate.User = UserDB.SelectById(4);
        //TicketToUpdate.Screening = MovieScreeningDB.SelectById(4);

        //tkdb.Update(TicketToUpdate);
        //int updated = tkdb.SaveChanges();

        //Console.WriteLine($"{updated} rows were updated");
        //Console.WriteLine(new string('-', 40));

        //// -------- DELETE --------
        //Console.WriteLine("Deleting last ticket...");

        //tkList = tkdb.SelectAll();
        //Ticket TicketToDelete = tkList.Last();

        //tkdb.Delete(TicketToDelete);
        //int deleted = tkdb.SaveChanges();

        //Console.WriteLine($"{deleted} rows were deleted");
        //Console.WriteLine(new string('-', 40));


        //Console.WriteLine("Tickets after all operations:");

        //tkList = tkdb.SelectAll();
        //foreach (Ticket tk in tkList)
        //    Console.WriteLine($"TicketId: {tk.Id}, ScreeningId: {tk.Screening.Id}, Price: {tk.TicketPrice}, UserId: {tk.User.Id}");

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




        /////// 🔹 Role
        //Console.WriteLine("Role:");

        //RoleDB Rdb = new RoleDB();
        //RoleList RList = Rdb.SelectAll();

        ////foreach (Role g in RList)
        ////    Console.WriteLine($"{g.Id}: {g.RoleName}");
        ////Console.WriteLine();

        ////Role RInsert = new Role();
        ////RInsert.RoleName = "other";
        ////Rdb.Insert(RInsert);

        ////int gen = Rdb.SaveChanges();
        ////Console.WriteLine($"{gen} rows were inserted");

        ////foreach (Role g in RList)
        ////    Console.WriteLine($"{g.Id}: {g.RoleName}");
        ////Console.WriteLine();


        //Role RoleToUpdate = RList.Last();
        //RoleToUpdate.RoleName = "Director";
        //Rdb.Update(RoleToUpdate);

        //int y = Rdb.SaveChanges();
        //Console.WriteLine($"{y} rows were updated");

        //foreach (Role R in RList)
        //    Console.WriteLine($"{R.Id}: {R.RoleName}");
        //Console.WriteLine();


        //Role RoleToDelete = RList.Last();
        //Rdb.Delete(RoleToDelete);

        //int z = Rdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");

        //foreach (Role g in RList)
        //    Console.WriteLine($"{g.Id}: {g.RoleName}");
        //Console.WriteLine();




        //////// 🔹 Gender
        //Console.WriteLine("Gender:");

        //GenderDB gdb = new GenderDB();
        //GenderList gList = gdb.SelectAll();

        //foreach (Gender g in gList)
        //    Console.WriteLine($"{g.Id}: {g.GenderName}");
        //Console.WriteLine();

        //Gender gInsert = new Gender();
        //gInsert.GenderName = "other";
        //gdb.Insert(gInsert);

        //int gen = gdb.SaveChanges();
        //Console.WriteLine($"{gen} rows were inserted");

        //foreach (Gender g in gList)
        //    Console.WriteLine($"{g.Id}: {g.GenderName}");
        //Console.WriteLine();


        //Gender GenderToUpdate = gList.Last();
        //GenderToUpdate.GenderName = "UpdatedGender";
        //gdb.Update(GenderToUpdate);

        //int y = gdb.SaveChanges();
        //Console.WriteLine($"{y} rows were updated");

        //foreach (Gender g in gList)
        //    Console.WriteLine($"{g.Id}: {g.GenderName}");
        //Console.WriteLine();


        //Gender GenderToDelete = gList.Last();
        //gdb.Delete(GenderToDelete);

        //int z = gdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");

        //foreach (Gender g in gList)
        //    Console.WriteLine($"{g.Id}: {g.GenderName}");
        //Console.WriteLine();






        //////// 🔹 Artist
        //ArtistDB adb = new ArtistDB();

        ////
        //// INSERT
        ////
        //Artist newArtist = new Artist
        //{
        //    ArtistName = "Test Artist",
        //    StartingYear = 2005,
        //    ArtistRole = RoleDB.SelectById(1)   // Make sure role id 1 exists
        //};

        //adb.Insert(newArtist);
        //int inserted = adb.SaveChanges();
        //Console.WriteLine($"{inserted} row(s) inserted.");

        ////
        //// UPDATE
        ////
        //ArtistList tempList = adb.SelectAll();
        //Artist artistToUpdate = tempList[0];

        //artistToUpdate.ArtistName = "Updated Artist Name";
        //artistToUpdate.StartingYear = 2010;
        //artistToUpdate.ArtistRole = RoleDB.SelectById(2); // Change role

        //adb.Update(artistToUpdate);
        //int updated = adb.SaveChanges();
        //Console.WriteLine($"{updated} row(s) updated.");

        ////
        //// DELETE
        ////
        ////tempList = adb.SelectAll();
        ////Artist artistToDelete = tempList[tempList.Count - 1];

        ////adb.Delete(artistToDelete);
        ////int deleted = adb.SaveChanges();
        ////Console.WriteLine($"{deleted} row(s) deleted.");

        ////
        //// FINAL REFRESH
        ////
        //Console.WriteLine("\n=== FINAL ARTIST LIST ===");

        //ArtistList finalList = adb.SelectAll();
        //foreach (Artist a in finalList)
        //{
        //    Console.WriteLine(
        //        $"Id: {a.Id}, Name: {a.ArtistName}, " +
        //        $"Year: {a.StartingYear}, Role: {a.ArtistRole?.RoleName}"
        //    );
        //}









        //    MovieGenreDB gdb = new MovieGenreDB();

        //        //
        //        // INSERT
        //        //
        //        //MovieGenre newGenre = new MovieGenre
        //        //{
        //        //    GenreName = "Genre"
        //        //};

        //        //gdb.Insert(newGenre);
        //        //int inserted = gdb.SaveChanges();
        //        //Console.WriteLine($"{inserted} row(s) inserted.");

        //        ////
        //        //// UPDATE
        //        ////
        //        MovieGenreList temp = gdb.SelectAll();
        //        MovieGenre toUpdate = temp[0];

        //        toUpdate.GenreName = "Adventure";

        //        gdb.Update(toUpdate);
        //        int updated = gdb.SaveChanges();
        //        Console.WriteLine($"{updated} row(s) updated.");


        //        //DELETE

        //        temp = gdb.SelectAll();
        //        MovieGenre toDelete = temp[temp.Count - 1];

        //        gdb.Delete(toDelete);
        //        int deleted = gdb.SaveChanges();
        //        Console.WriteLine($"{deleted} row(s) deleted.");

        //        //
        //        // FINAL REFRESH
        //        //
        //        Console.WriteLine("\n=== FINAL GENRE LIST ===");
        //        MovieGenreList finalList = gdb.SelectAll();

        //        foreach (MovieGenre g in finalList)
        //        {
        //            Console.WriteLine($"Id: {g.Id}, GenreName: {g.GenreName}");
        //        }

        //        Console.WriteLine("\nProgram completed.");
        //    }
        //}

        //Console.WriteLine("✅ All DB tests finished.");
        //Console.ReadLine();



    }
}





