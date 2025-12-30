using Model;
using MoviesInterface;

namespace ServerTest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            MoviesFunctions service = new MoviesFunctions();

            CityList cities = await service.GetAllCities();
            foreach (City city in cities)
                Console.WriteLine(city);
            Console.WriteLine();

            City newCity = new City { CityName = "בית אל" };
            await service.InsertACity(newCity);

            cities = await service.GetAllCities();
            foreach (City city in cities)
                Console.WriteLine(city);
            Console.WriteLine();

            City updateCity = cities.Last();
            updateCity.CityName = "נתניה";
            await service.UpdateACity(updateCity);

            cities = await service.GetAllCities();
            foreach (City city in cities)
                Console.WriteLine(city);
            Console.WriteLine();

            City cityToDelete = cities.Last();
            await service.DeleteACity(cityToDelete);

            cities = await service.GetAllCities();
            foreach (City city in cities)
                Console.WriteLine(city);
            Console.WriteLine();

            Console.Read();
        }
    }
}
