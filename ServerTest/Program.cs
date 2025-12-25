using ApiInterface;
using Model;

namespace ServerTest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            ApiService service = new ApiService();

            CityList clist = await service.GetAllCities();
            foreach (City city in clist)
                Console.WriteLine(city.CityName);

            CityList cities = await service.GetAllCities();

            City cityToDelete = cities.Last();
            await service.DeleteACity(cityToDelete);

            City newCity = new City { CityName = "בית אל" };
            await service.InsertACity(newCity);

            City updateCity = cities.First();
            updateCity.CityName = "נתניה";
            await service.UpdateACity(updateCity);
        }
    }
}
