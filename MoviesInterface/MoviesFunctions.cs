using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviesInterface
{
    public class MoviesFunctions : Moviesinface
    {
        private readonly string baseUrl = "https://tx1k0wkz-5096.euw.devtunnels.ms/";
        private readonly HttpClient client;

        public MoviesFunctions()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("X-Tunnel-Skip-AntiPhishing-Scan", "true");
        }


        #region CUSTOMER
        public async Task<CustomerList> GetAllCustomers()
        {
            try
            {
                // Returns an empty list instead of null to prevent crashing
                return await client.GetFromJsonAsync<CustomerList>("api/Customer/SelectAllCustomers") ?? new CustomerList();
            }
            catch { return new CustomerList(); }
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await client.GetFromJsonAsync<Customer>($"api/Customer/SelectByIdxCustomer/{id}");
        }

        public async Task<int> InsertCustomer(Customer c)
        {
            var res = await client.PostAsJsonAsync("api/Customer/InsertCustomer", c);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCustomer(Customer c)
        {
            var res = await client.PutAsJsonAsync("api/Customer/UpdateCustomer", c);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteCustomer(Customer c)
        {
            // Matches Swagger DELETE route: api/Customer/DeleteCustomer/{id}
            var res = await client.DeleteAsync($"api/Customer/DeleteCustomer/{c.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region CITY
        public async Task<CityList> GetAllCities() => await client.GetFromJsonAsync<CityList>("api/City/SelectAllCities") ?? new CityList();
        public async Task<City?> GetCityById(int id) => await client.GetFromJsonAsync<City>($"api/City/SelectByIdxCity/{id}");
        public async Task<int> InsertACity(City city) => (await client.PostAsJsonAsync("api/City/InsertCity", city)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateACity(City city) => (await client.PutAsJsonAsync("api/City/UpdateCity", city)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteACity(City city) => (await client.DeleteAsync($"api/City/DeleteCity/{city.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region GENDER
        public async Task<GenderList> GetAllGenders() => await client.GetFromJsonAsync<GenderList>("api/Gender/SelectAllGenders") ?? new GenderList();
        public async Task<Gender?> GetGenderById(int id) => await client.GetFromJsonAsync<Gender>($"api/Gender/SelectByIdxGender/{id}");
        public async Task<int> InsertGender(Gender g) => (await client.PostAsJsonAsync("api/Gender/InsertGender", g)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateGender(Gender g) => (await client.PutAsJsonAsync("api/Gender/UpdateGender", g)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteGender(Gender g) => (await client.DeleteAsync($"api/Gender/DeleteGender/{g.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region ROLE
        public async Task<RoleList> GetAllRoles() => await client.GetFromJsonAsync<RoleList>("api/Role/SelectAllRoles") ?? new RoleList();
        public async Task<Role?> GetRoleById(int id) => await client.GetFromJsonAsync<Role>($"api/Role/SelectByIdxRole/{id}");
        public async Task<int> InsertRole(Role role) => (await client.PostAsJsonAsync("api/Role/InsertRole", role)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateRole(Role role) => (await client.PutAsJsonAsync("api/Role/UpdateRole", role)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteRole(Role role) => (await client.DeleteAsync($"api/Role/DeleteRole/{role.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region ARTIST
        public async Task<ArtistList> GetAllArtists() => await client.GetFromJsonAsync<ArtistList>("api/Artist/SelectAllArtists") ?? new ArtistList();
        public async Task<Artist?> GetArtistById(int id) => await client.GetFromJsonAsync<Artist>($"api/Artist/SelectByIdxArtist/{id}");
        public async Task<int> InsertArtist(Artist a) => (await client.PostAsJsonAsync("api/Artist/InsertArtist", a)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateArtist(Artist a) => (await client.PutAsJsonAsync("api/Artist/UpdateArtist", a)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteArtist(Artist a) => (await client.DeleteAsync($"api/Artist/DeleteArtist/{a.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region MOVIE HALL
        public async Task<MovieHallList> GetAllMovieHalls() => await client.GetFromJsonAsync<MovieHallList>("api/MovieHall/SelectAllMovieHalls") ?? new MovieHallList();
        public async Task<MovieHall?> GetMovieHallById(int id) => await client.GetFromJsonAsync<MovieHall>($"api/MovieHall/SelectByIdxMovieHall/{id}");
        public async Task<int> InsertMovieHall(MovieHall mh) => (await client.PostAsJsonAsync("api/MovieHall/InsertMovieHall", mh)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateMovieHall(MovieHall mh) => (await client.PutAsJsonAsync("api/MovieHall/UpdateMovieHall", mh)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteMovieHall(MovieHall mh) => (await client.DeleteAsync($"api/MovieHall/DeleteMovieHall/{mh.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region MOVIE GENRE
        public async Task<MovieGenreList> GetAllMovieGenres() => await client.GetFromJsonAsync<MovieGenreList>("api/MovieGenre/SelectAllMovieGenres") ?? new MovieGenreList();
        public async Task<MovieGenre?> GetMovieGenreById(int id) => await client.GetFromJsonAsync<MovieGenre>($"api/MovieGenre/SelectByIdxMovieGenre/{id}");
        public async Task<int> InsertMovieGenre(MovieGenre mg) => (await client.PostAsJsonAsync("api/MovieGenre/InsertMovieGenre", mg)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateMovieGenre(MovieGenre mg) => (await client.PutAsJsonAsync("api/MovieGenre/UpdateMovieGenre", mg)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteMovieGenre(MovieGenre mg) => (await client.DeleteAsync($"api/MovieGenre/DeleteMovieGenre/{mg.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region MOVIE SCREENING
        public async Task<MovieScreeningList> GetAllMovieScreenings() => await client.GetFromJsonAsync<MovieScreeningList>("api/MovieScreening/SelectAllMovieScreenings") ?? new MovieScreeningList();
        public async Task<MovieScreening?> GetMovieScreeningById(int id) => await client.GetFromJsonAsync<MovieScreening>($"api/MovieScreening/SelectByIdxMovieScreening/{id}");
        public async Task<int> InsertMovieScreening(MovieScreening ms) => (await client.PostAsJsonAsync("api/MovieScreening/InsertMovieScreening", ms)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateMovieScreening(MovieScreening ms) => (await client.PutAsJsonAsync("api/MovieScreening/UpdateMovieScreening", ms)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteMovieScreening(MovieScreening ms) => (await client.DeleteAsync($"api/MovieScreening/DeleteMovieScreening/{ms.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region ACTORS IN MOVIE
        public async Task<ActorsInMovieList> GetAllActorsInMovies() => await client.GetFromJsonAsync<ActorsInMovieList>("api/ActorsInMovie/SelectAllActorsInMovies") ?? new ActorsInMovieList();
        public async Task<ActorsInMovie?> GetActorsInMovieById(int id) => await client.GetFromJsonAsync<ActorsInMovie>($"api/ActorsInMovie/SelectByIdxActorsInMovie/{id}");
        public async Task<int> InsertActorsInMovie(ActorsInMovie aim) => (await client.PostAsJsonAsync("api/ActorsInMovie/InsertActorsInMovie", aim)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateActorsInMovie(ActorsInMovie aim) => (await client.PutAsJsonAsync("api/ActorsInMovie/UpdateActorsInMovie", aim)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteActorsInMovie(ActorsInMovie aim) => (await client.DeleteAsync($"api/ActorsInMovie/DeleteActorsInMovie/{aim.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region GENRES IN MOVIES
        public async Task<GenresinMoviesList> GetAllGenresInMovies() => await client.GetFromJsonAsync<GenresinMoviesList>("api/GenresInMovies/SelectAllGenresInMovies") ?? new GenresinMoviesList();
        public async Task<GenresinMovies?> GetGenresInMoviesById(int id) => await client.GetFromJsonAsync<GenresinMovies>($"api/GenresInMovies/SelectByIdxGenresInMovies/{id}");
        public async Task<int> InsertGenresInMovies(GenresinMovies gm) => (await client.PostAsJsonAsync("api/GenresInMovies/InsertGenresInMovies", gm)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateGenresInMovies(GenresinMovies gm) => (await client.PutAsJsonAsync("api/GenresInMovies/UpdateGenresInMovies", gm)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteGenresInMovies(GenresinMovies gm) => (await client.DeleteAsync($"api/GenresInMovies/DeleteGenresInMovies/{gm.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region MOVIE
        public async Task<MovieList> GetAllMovies() => await client.GetFromJsonAsync<MovieList>("api/Movie/SelectAllMovies") ?? new MovieList();
        public async Task<Movie?> GetMovieById(int id) => await client.GetFromJsonAsync<Movie>($"api/Movie/SelectByIdxMovie/{id}");
        public async Task<int> InsertMovie(Movie m) => (await client.PostAsJsonAsync("api/Movie/InsertMovie", m)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateMovie(Movie m) => (await client.PutAsJsonAsync("api/Movie/UpdateMovie", m)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteMovie(Movie m) => (await client.DeleteAsync($"api/Movie/DeleteMovie/{m.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region TICKET
        public async Task<TicketList> GetAllTickets() => await client.GetFromJsonAsync<TicketList>("api/Ticket/SelectAllTickets") ?? new TicketList();
        public async Task<Ticket?> GetTicketById(int id) => await client.GetFromJsonAsync<Ticket>($"api/Ticket/SelectByIdxTicket/{id}");
        public async Task<int> InsertTicket(Ticket t) => (await client.PostAsJsonAsync("api/Ticket/InsertTicket", t)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateTicket(Ticket t) => (await client.PutAsJsonAsync("api/Ticket/UpdateTicket", t)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteTicket(Ticket t) => (await client.DeleteAsync($"api/Ticket/DeleteTicket/{t.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region THEATER
        public async Task<TheaterList> GetAllTheaters() => await client.GetFromJsonAsync<TheaterList>("api/Theater/SelectAllTheaters") ?? new TheaterList();
        public async Task<Theater?> GetTheaterById(int id) => await client.GetFromJsonAsync<Theater>($"api/Theater/SelectByIdxTheater/{id}");
        public async Task<int> InsertTheater(Theater theater) => (await client.PostAsJsonAsync("api/Theater/InsertTheater", theater)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateTheater(Theater theater) => (await client.PutAsJsonAsync("api/Theater/UpdateTheater", theater)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteTheater(Theater theater) => (await client.DeleteAsync($"api/Theater/DeleteTheater/{theater.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region USER
        public async Task<UserList> GetAllUsers() => await client.GetFromJsonAsync<UserList>("api/User/SelectAllUsers") ?? new UserList();
        public async Task<User?> GetUserById(int id) => await client.GetFromJsonAsync<User>($"api/User/SelectByIdxUser/{id}");
        public async Task<int> InsertUser(User user) => (await client.PostAsJsonAsync("api/User/InsertUser", user)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateUser(User user) => (await client.PutAsJsonAsync("api/User/UpdateUser", user)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteUser(User user) => (await client.DeleteAsync($"api/User/DeleteUser/{user.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region AGE RATING
        public async Task<AgeRatingList> GetAllAgeRatingInMovies() => await client.GetFromJsonAsync<AgeRatingList>("api/AgeRating/SelectAllAgeRatings") ?? new AgeRatingList();
        public async Task<AgeRating?> GetAgeRatingById(int id) => await client.GetFromJsonAsync<AgeRating>($"api/AgeRating/SelectByIdxAgeRating/{id}");
        public async Task<int> InsertAgeRating(AgeRating ageRating) => (await client.PostAsJsonAsync("api/AgeRating/InsertAgeRating", ageRating)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateAgeRating(AgeRating ageRating) => (await client.PutAsJsonAsync("api/AgeRating/UpdateAgeRating", ageRating)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteAgeRating(AgeRating ageRating) => (await client.DeleteAsync($"api/AgeRating/DeleteAgeRating/{ageRating.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion

        #region OPERATOR
        public async Task<OperatorList> GetAllOperators() => await client.GetFromJsonAsync<OperatorList>("api/Operator/SelectAllOperators") ?? new OperatorList();
        public async Task<Operator?> GetOperatorById(int id) => await client.GetFromJsonAsync<Operator>($"api/Operator/SelectByIdxOperator/{id}");
        public async Task<int> InsertOperator(Operator op) => (await client.PostAsJsonAsync("api/Operator/InsertOperator", op)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> UpdateOperator(Operator op) => (await client.PutAsJsonAsync("api/Operator/UpdateOperator", op)).IsSuccessStatusCode ? 1 : 0;
        public async Task<int> DeleteOperator(Operator op) => (await client.DeleteAsync($"api/Operator/DeleteOperator/{op.Id}")).IsSuccessStatusCode ? 1 : 0;
        #endregion
    }
}