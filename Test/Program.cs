using Model;
using System;
using System.Linq;
using ViewModel;

namespace Arielproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunAllTests();
            Console.WriteLine("\n✅ All DB tests finished successfully.");
            Console.ReadLine();
        }

        static void RunAllTests()
        {
            // ================= OPERATOR =================
            OperatorDB odb = new OperatorDB();

            Operator newOp = new Operator
            {
                Username = "Operator1",
                Pass = "1234",
                Email = "op1@mail.com",
                RoleName = RoleDB.SelectById(1)
            };

            odb.Insert(newOp);
            Console.WriteLine($"{odb.SaveChanges()} operator inserted");

            OperatorList operators = odb.SelectAll();
            Operator opToUpdate = operators[0];
            opToUpdate.Email = "updated@mail.com";
            opToUpdate.RoleName = RoleDB.SelectById(2);

            odb.Update(opToUpdate);
            Console.WriteLine($"{odb.SaveChanges()} operator updated");

            odb.Delete(operators.Last());
            Console.WriteLine($"{odb.SaveChanges()} operator deleted");

            // ================= GENRES IN MOVIES =================
            GenresInMoviesDB gmdb = new GenresInMoviesDB();

            GenresinMovies gm = new GenresinMovies
            {
                MG = MovieGenreDB.SelectById(1),
                M = MovieDB.SelectById(1)
            };

            gmdb.Insert(gm);
            Console.WriteLine($"{gmdb.SaveChanges()} genre-movie inserted");

            GenresinMoviesList gmList = gmdb.SelectAll();
            GenresinMovies gmUpdate = gmList[0];
            gmUpdate.MG = MovieGenreDB.SelectById(2);
            gmUpdate.M = MovieDB.SelectById(2);

            gmdb.Update(gmUpdate);
            Console.WriteLine($"{gmdb.SaveChanges()} genre-movie updated");

            gmdb.Delete(gmList.Last());
            Console.WriteLine($"{gmdb.SaveChanges()} genre-movie deleted");

            // ================= MOVIE HALL =================
            MovieHallDB hdb = new MovieHallDB();

            MovieHall hall = new MovieHall
            {
                HallName = "Hall A",
                AmountOfSeats = 200,
                Theater = TheaterDB.SelectById(1)
            };

            hdb.Insert(hall);
            Console.WriteLine($"{hdb.SaveChanges()} hall inserted");

            MovieHallList halls = hdb.SelectAll();
            MovieHall hallUpdate = halls[0];
            hallUpdate.HallName = "Updated Hall";
            hallUpdate.AmountOfSeats = 250;
            hallUpdate.Theater = TheaterDB.SelectById(2);

            hdb.Update(hallUpdate);
            Console.WriteLine($"{hdb.SaveChanges()} hall updated");

            hdb.Delete(halls.Last());
            Console.WriteLine($"{hdb.SaveChanges()} hall deleted");

            // ================= CUSTOMER =================
            CustomerDB cdb = new CustomerDB();

            Customer cust = new Customer
            {
                Username = "Customery",
                Pass = "pass123",
                Email = "newcustomer@example.com",
                DateOfBirth = new DateTime(2000, 1, 15),
                CustomerGender = GenderDB.SelectById(1),
                RepeatCustomer = false
            };

            cdb.Insert(cust);
            Console.WriteLine($"{cdb.SaveChanges()} customer inserted");

            CustomerList customers = cdb.SelectAll();
            Customer custUpdate = customers[0];
            custUpdate.Email = "updatedcustomer@example.com";
            custUpdate.RepeatCustomer = true;
            custUpdate.CustomerGender = GenderDB.SelectById(2);

            cdb.Update(custUpdate);
            Console.WriteLine($"{cdb.SaveChanges()} customer updated");

            cdb.Delete(customers.Last());
            Console.WriteLine($"{cdb.SaveChanges()} customer deleted");

            // ================= USER =================
            UserDB udb = new UserDB();

            User user = new User
            {
                Username = "JohnDoe",
                Pass = "12345",
                Email = "john@example.com"
            };

            udb.Insert(user);
            Console.WriteLine($"{udb.SaveChanges()} user inserted");

            UserList users = udb.SelectAll();
            User userUpdate = users[0];
            userUpdate.Username = "arielh1";
            userUpdate.Pass = "eran1966";
            userUpdate.Email = "arielhammer1@gmail.com";

            udb.Update(userUpdate);
            Console.WriteLine($"{udb.SaveChanges()} user updated");

            udb.Delete(users.Last());
            Console.WriteLine($"{udb.SaveChanges()} user deleted");

            // ================= MOVIE =================
            MovieDB mdb = new MovieDB();

            Movie movie = new Movie
            {
                MovieName = "how to kill a loving bird",
                MovieLength = 180,
                ReleaseDate = new DateTime(2000, 12, 22),
                AgeRatingName = AgeRatingDB.SelectById(2),
                Genre = MovieGenreDB.SelectById(3)
            };

            mdb.Insert(movie);
            Console.WriteLine($"{mdb.SaveChanges()} movie inserted");

            MovieList movies = mdb.SelectAll();
            Movie movieUpdate = movies[0];
            movieUpdate.MovieName = "Movie updated";

            mdb.Update(movieUpdate);
            Console.WriteLine($"{mdb.SaveChanges()} movie updated");

            mdb.Delete(movies.Last());
            Console.WriteLine($"{mdb.SaveChanges()} movie deleted");

            // ================= THEATER =================
            TheaterDB tdb = new TheaterDB();

            Theater theater = new Theater
            {
                NameOfTheater = "Cinema City",
                Address = "Main Street",
                StreetNumber = 10,
                CityCode = CityDB.SelectById(1)
            };

            tdb.Insert(theater);
            Console.WriteLine($"{tdb.SaveChanges()} theater inserted");

            TheaterList theaters = tdb.SelectAll();
            Theater theaterUpdate = theaters[0];
            theaterUpdate.NameOfTheater = "Updated Cinema";
            theaterUpdate.StreetNumber = 22;
            theaterUpdate.CityCode = CityDB.SelectById(2);

            tdb.Update(theaterUpdate);
            Console.WriteLine($"{tdb.SaveChanges()} theater updated");

            tdb.Delete(theaters.Last());
            Console.WriteLine($"{tdb.SaveChanges()} theater deleted");
        }
    }
}
