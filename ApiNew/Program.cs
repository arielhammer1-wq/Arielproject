
using Model;

namespace ApiNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            static async Task Main(string[] args)
            {
                HttpClient client = new HttpClient();
                string URI = "http://localhost:5096/api/Select/CitySelector";
                CityList cities = await client.GetFromJsonAsync<CityList>(URI);
                foreach (City city in cities)
                {
                    Console.Out.WriteLineAsync(city.CityName);
                }

                URI = "http://localhost:5096/api/Select/StudentSelector";
                MovieList Movies = await client.GetFromJsonAsync<MovieList>(URI); foreach (Movie m in Movies)
                    await Console.Out.WriteLineAsync(m.MovieName +m.MovieLength);
            }
        }
    }
}
