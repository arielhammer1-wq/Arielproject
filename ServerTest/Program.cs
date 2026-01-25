using Model;
using MoviesInterface;
using ViewModel;

namespace ServerTest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            MoviesFunctions service = new MoviesFunctions();

            // ================= CITY =================
            int cityInserted = 0, cityUpdated = 0, cityDeleted = 0;

            Console.WriteLine("=== CITY ===");
            CityList cities = await service.GetAllCities();
            PrintCities(cities);

            cityInserted += await service.InsertACity(new City { CityName = "TestCity" });
            cities = await service.GetAllCities();
            PrintCities(cities);

            City cityToUpdate = cities.Last();
            cityToUpdate.CityName = "UpdatedCity";
            cityUpdated += await service.UpdateACity(cityToUpdate);

            cities = await service.GetAllCities();
            PrintCities(cities);

            cityDeleted += await service.DeleteACity(cities.Last());
            cities = await service.GetAllCities();
            PrintCities(cities);

            Console.WriteLine($"CITY → Inserted:{cityInserted} Updated:{cityUpdated} Deleted:{cityDeleted}\n");

            // ================= GENDER =================
            int genderInserted = 0, genderUpdated = 0, genderDeleted = 0;

            Console.WriteLine("=== GENDER ===");
            GenderList genders = await service.GetAllGenders();
            PrintGenders(genders);

            genderInserted += await service.InsertGender(new Gender { GenderName = "Other" });
            genders = await service.GetAllGenders();
            PrintGenders(genders);

            Gender genderToUpdate = genders.Last();
            genderToUpdate.GenderName = "UpdatedGender";
            genderUpdated += await service.UpdateGender(genderToUpdate);

            genders = await service.GetAllGenders();
            PrintGenders(genders);

            genderDeleted += await service.DeleteGender(genders.Last());
            genders = await service.GetAllGenders();
            PrintGenders(genders);

            Console.WriteLine($"GENDER → Inserted:{genderInserted} Updated:{genderUpdated} Deleted:{genderDeleted}\n");

            // ================= ROLE =================
            int roleInserted = 0, roleUpdated = 0, roleDeleted = 0;

            Console.WriteLine("=== ROLE ===");
            RoleList roles = await service.GetAllRoles();
            PrintRoles(roles);

            roleInserted += await service.InsertRole(new Role { RoleName = "TestRole" });
            roles = await service.GetAllRoles();
            PrintRoles(roles);

            Role roleToUpdate = roles.Last();
            roleToUpdate.RoleName = "UpdatedRole";
            roleUpdated += await service.UpdateRole(roleToUpdate);

            roles = await service.GetAllRoles();
            PrintRoles(roles);

            roleDeleted += await service.DeleteRole(roles.Last());
            roles = await service.GetAllRoles();
            PrintRoles(roles);

            Console.WriteLine($"ROLE → Inserted:{roleInserted} Updated:{roleUpdated} Deleted:{roleDeleted}\n");

            // ================= CUSTOMER =================
            int customerInserted = 0, customerUpdated = 0, customerDeleted = 0;

            Console.WriteLine("=== CUSTOMER ===");
            CustomerList customers = await service.GetAllCustomers();
            PrintCustomers(customers);

            customerInserted += await service.InsertCustomer(new Customer
            {
                Username = "test",
                Pass = "1234",
                Email = "test@mail.com",
                DateOfBirth = new DateTime(2000, 1, 1),
                CustomerGender = genders.First(),
                RepeatCustomer = false
            });

            customers = await service.GetAllCustomers();
            PrintCustomers(customers);

            Customer custToUpdate = customers.Last();
            custToUpdate.Email = "updated@mail.com";
            custToUpdate.RepeatCustomer = true;
            customerUpdated += await service.UpdateCustomer(custToUpdate);

            customers = await service.GetAllCustomers();
            PrintCustomers(customers);

            customerDeleted += await service.DeleteCustomer(customers.Last());
            customers = await service.GetAllCustomers();
            PrintCustomers(customers);

            Console.WriteLine($"CUSTOMER → Inserted:{customerInserted} Updated:{customerUpdated} Deleted:{customerDeleted}\n");

            // ================= MOVIE =================
            int movieInserted = 0, movieUpdated = 0, movieDeleted = 0;

            Console.WriteLine("=== MOVIE ===");
            MovieList movies = await service.GetAllMovies();
            PrintMovies(movies);

            movieInserted += await service.InsertMovie(new Movie
            {
                MovieName = "Test Movie",
                MovieLength = 120,
                ReleaseDate = DateTime.Now,
                Genre = (await service.GetAllMovieGenres()).First(),
                AgeRatingName = AgeRatingDB.SelectById(1)
            });

            movies = await service.GetAllMovies();
            PrintMovies(movies);

            Movie movieToUpdate = movies.Last();
            movieToUpdate.MovieName = "Updated Movie";
            movieUpdated += await service.UpdateMovie(movieToUpdate);

            movies = await service.GetAllMovies();
            PrintMovies(movies);

            movieDeleted += await service.DeleteMovie(movies.Last());
            movies = await service.GetAllMovies();
            PrintMovies(movies);

            Console.WriteLine($"MOVIE → Inserted:{movieInserted} Updated:{movieUpdated} Deleted:{movieDeleted}\n");

            // ================= THEATER =================
            int theaterInserted = 0, theaterUpdated = 0, theaterDeleted = 0;

            Console.WriteLine("=== THEATER ===");
            TheaterList theaters = await service.GetAllTheaters();
            PrintTheaters(theaters);

            theaterInserted += await service.InsertTheater(new Theater
            {
                NameOfTheater = "Test Theater",
                Address = "Main St",
                StreetNumber = 1,
                CityCode = cities.First()
            });

            theaters = await service.GetAllTheaters();
            PrintTheaters(theaters);

            Theater theaterToUpdate = theaters.Last();
            theaterToUpdate.NameOfTheater = "Updated Theater";
            theaterUpdated += await service.UpdateTheater(theaterToUpdate);

            theaters = await service.GetAllTheaters();
            PrintTheaters(theaters);

            theaterDeleted += await service.DeleteTheater(theaters.Last());
            theaters = await service.GetAllTheaters();
            PrintTheaters(theaters);

            Console.WriteLine($"THEATER → Inserted:{theaterInserted} Updated:{theaterUpdated} Deleted:{theaterDeleted}\n");

            Console.WriteLine("=== ALL TESTS FINISHED ===");
            Console.ReadLine();
        }

        // ================= PRINT HELPERS =================

        static void PrintCities(CityList list)
        {
            foreach (City c in list)
                Console.WriteLine($"{c.Id} - {c.CityName}");
            Console.WriteLine();
        }

        static void PrintGenders(GenderList list)
        {
            foreach (Gender g in list)
                Console.WriteLine($"{g.Id} - {g.GenderName}");
            Console.WriteLine();
        }

        static void PrintRoles(RoleList list)
        {
            foreach (Role r in list)
                Console.WriteLine($"{r.Id} - {r.RoleName}");
            Console.WriteLine();
        }

        static void PrintCustomers(CustomerList list)
        {
            foreach (Customer c in list)
                Console.WriteLine($"{c.Id} - {c.Username} - {c.Email}");
            Console.WriteLine();
        }

        static void PrintMovies(MovieList list)
        {
            foreach (Movie m in list)
                Console.WriteLine($"{m.Id} - {m.MovieName}");
            Console.WriteLine();
        }

        static void PrintTheaters(TheaterList list)
        {
            foreach (Theater t in list)
                Console.WriteLine($"{t.Id} - {t.NameOfTheater}");
            Console.WriteLine();
        }
    }
}
