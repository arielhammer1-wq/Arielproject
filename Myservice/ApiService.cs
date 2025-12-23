using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Myservice
{
    public class ApiService : MyApiService
    {
        string URI = "http://localhost:5096";
        public async Task<int> DeleteACity(City city)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteActorsInMovie(ActorsInMovie aim)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteGender(Gender gender)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteGenresInMovies(GenresinMovies gm)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteMovieGenre(MovieGenre genre)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteMovieHall(MovieHall hall)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteMovieScreening(MovieScreening screening)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteOperator(Operator op)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteRole(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteTheater(Theater theater)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<ActorsInMovieList> GetAllActorsInMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<ArtistList> GetAllArtists()
        {
            throw new NotImplementedException();
        }

       private static readonly HttpClient client = new HttpClient();

public async Task<CityList> GetAllCities()
{
    try
    {
        string url = "http://localhost:5096/api/City/SelectAllCities";
        
        CityList? cities = await client.GetFromJsonAsync<CityList>(url);

        return cities ?? new CityList(); // NEVER return null
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
        return new CityList();  // safe default
    }
}


        public async Task<CustomerList> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public async Task<GenderList> GetAllGenders()
        {
            throw new NotImplementedException();
        }

        public async Task<GenresinMoviesList> GetAllGenresInMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<MovieGenreList> GetAllMovieGenres()
        {
            throw new NotImplementedException();
        }

        public async Task<MovieHallList> GetAllMovieHalls()
        {
            throw new NotImplementedException();
        }

        public async Task<MovieList> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<MovieScreeningList> GetAllMovieScreenings()
        {
            throw new NotImplementedException();
        }

        public async Task<OperatorList> GetAllOperators()
        {
            throw new NotImplementedException();
        }

        public async Task<RoleList> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<TheaterList> GetAllTheaters()
        {
            throw new NotImplementedException();
        }

        public async Task<TicketList> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertACity(City city)
        {

            // Insert post
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5096/api/Select/InsertACity";
            var x = await client.PostAsJsonAsync<City>(URI, city); 
            if (x.IsSuccessStatusCode == true)
                return 1;
            return 0;
        }

        public async Task<int> InsertActorsInMovie(ActorsInMovie aim)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertGender(Gender gender)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertGenresInMovies(GenresinMovies gm)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertMovieGenre(MovieGenre genre)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertMovieHall(MovieHall hall)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertMovieScreening(MovieScreening screening)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertOperator(Operator op)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertRole(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertTheater(Theater theater)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateACity(City city)
        {
            HttpClient client = new HttpClient();
           string URI = "http://localhost:5096/api/Select/UpdateACity";
            var z = await client.PutAsJsonAsync<City>(URI, city);
            HttpResponseMessage msg = await client.PutAsJsonAsync<City>(URI, city);
            if(msg.IsSuccessStatusCode)
                return 1;
            return 0;
        }

        public async Task<int> UpdateActorsInMovie(ActorsInMovie aim)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateGender(Gender gender)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateGenresInMovies(GenresinMovies gm)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateMovieGenre(MovieGenre genre)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateMovieHall(MovieHall hall)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateMovieScreening(MovieScreening screening)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateOperator(Operator op)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateTheater(Theater theater)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
