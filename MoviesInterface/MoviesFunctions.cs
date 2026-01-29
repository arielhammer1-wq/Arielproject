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
    public class MoviesFunctions: Moviesinface
    {
        private readonly string baseUrl = "https://t1tphxjm-5096.euw.devtunnels.ms/"/*"http://localhost:5096/"*/;
        private readonly HttpClient client;

        public MoviesFunctions()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("X-Tunnel-Skip-AntiPhishing-Scan","true");

        }

        // --------------------------
        #region CITY
        // --------------------------
        public async Task<CityList> GetAllCities()
        {
            try
            {
                return await client.GetFromJsonAsync<CityList>("api/City/SelectAllCities");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllCities: {ex.Message}");
            }
        }
        public async Task<City?> GetCityById(int id)
        {
            return await client.GetFromJsonAsync<City>($"api/City/SelectByIdxCity{id}");
        }

        public async Task<int> InsertACity(City city)
        {
            var res = await client.PostAsJsonAsync("api/City/InsertCity", city);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateACity(City city)
        {
            var res = await client.PutAsJsonAsync("api/City/UpdateCity", city);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteACity(City city)
        {
            var res = await client.DeleteAsync($"api/City/DeleteCity/{city.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
#endregion
        // --------------------------
        #region CUSTOMER
        // --------------------------
        public async Task<CustomerList> GetAllCustomers()
        {
            try
            {
                return await client.GetFromJsonAsync<CustomerList>("api/Customer/SelectAllCustomers")
                       ?? new CustomerList();
            }
            catch { return new CustomerList(); }
        }
        public async Task<Customer?> GetCustomerById(int id)
        {
            return await client.GetFromJsonAsync<Customer>($"api/Customer/SelectByIdxCustomer{id}");
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
            var res = await client.DeleteAsync($"api/Customer/DeleteCustomer/{c.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
#endregion
        // --------------------------
        #region GENDER
        // --------------------------
        public async Task<GenderList> GetAllGenders()
        {
            try
            {
                return await client.GetFromJsonAsync<GenderList>("api/Gender/SelectAllGenders")
                       ?? new GenderList();
            }
            catch { return new GenderList(); }
        }
        public async Task<Gender?> GetGenderById(int id)
        {
            return await client.GetFromJsonAsync<Gender>($"api/Gender/SelectByIdxGender{id}");
        }

        public async Task<int> InsertGender(Gender g)
        {
            var res = await client.PostAsJsonAsync("api/Gender/InsertGender", g);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateGender(Gender g)
        {
            var res = await client.PutAsJsonAsync("api/Gender/UpdateGender", g);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteGender(Gender g)
        {
            var res = await client.DeleteAsync($"api/Gender/DeleteGender/{g.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
#endregion
        // --------------------------
        #region ROLE
        // --------------------------
        public async Task<RoleList> GetAllRoles()
        {
            try
            {
                return await client.GetFromJsonAsync<RoleList>("api/Role/SelectAllRoles")
                       ?? new RoleList();
            }
            catch { return new RoleList(); }
        }
        public async Task<Role?> GetRoleById(int id)
        {
            return await client.GetFromJsonAsync<Role>($"api/Role/SelectByIdxRole{id}");
        }

        public async Task<int> InsertRole(Role role)
        {
            var res = await client.PostAsJsonAsync("api/Role/InsertRole", role);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateRole(Role role)
        {
            var res = await client.PutAsJsonAsync("api/Role/UpdateRole", role);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteRole(Role role)
        {
            var res = await client.DeleteAsync($"api/Role/DeleteRole/{role.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion
        // --------------------------
        #region OPERATOR
        // --------------------------
        public async Task<OperatorList> GetAllOperators()
        {
            try
            {
                return await client.GetFromJsonAsync<OperatorList>("api/Operator/SelectAllOperators")
                       ?? new OperatorList();
            }
            catch { return new OperatorList(); }
        }
        public async Task<Operator?> GetOperatorById(int id)
        {
            return await client.GetFromJsonAsync<Operator>($"api/Operator/SelectByIdxOperator{id}");
        }

        public async Task<int> InsertOperator(Operator op)
        {
            var res = await client.PostAsJsonAsync("api/Operator/InsertOperator", op);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateOperator(Operator op)
        {
            var res = await client.PutAsJsonAsync("api/Operator/UpdateOperator", op);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteOperator(Operator op)
        {
            var res = await client.DeleteAsync($"api/Operator/DeleteOperator{op.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
#endregion
        // --------------------------
        #region ARTIST
        // --------------------------
        public async Task<ArtistList> GetAllArtists()
        {
            try
            {
                return await client.GetFromJsonAsync<ArtistList>("api/Artist/SelectAllArtists")
                       ?? new ArtistList();
            }
            catch { return new ArtistList(); }
        }

        public async Task<int> InsertArtist(Artist a)
        {
            var res = await client.PostAsJsonAsync("api/Artist/InsertArtist", a);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateArtist(Artist a)
        {
            var res = await client.PutAsJsonAsync("api/Artist/UpdateArtist", a);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteArtist(Artist a)
        {
            var res = await client.DeleteAsync($"api/Artist/DeleteArtist/{a.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<Artist?> GetArtistById(int id)
        {
            return await client.GetFromJsonAsync<Artist>($"api/Artist/SelectByIdxArtist{id}");
        }

        #endregion
        // --------------------------
        #region ACTORS IN MOVIE
        // --------------------------
        public async Task<ActorsInMovieList> GetAllActorsInMovies()
        {
            try
            {
                return await client.GetFromJsonAsync<ActorsInMovieList>("api/ActorsInMovie/SelectAllActorsInMovies")
                       ?? new ActorsInMovieList();
            }
            catch { return new ActorsInMovieList(); }
        }
        public async Task<ActorsInMovie?> GetActorsInMovieById(int id)
        {
            return await client.GetFromJsonAsync<ActorsInMovie>($"api/ActorsInMovie/SelectByIdxActorsInMovie{id}");
        }

        public async Task<int> InsertActorsInMovie(ActorsInMovie aim)
        {
            var res = await client.PostAsJsonAsync("api/ActorsInMovie/InsertActorsInMovie", aim);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateActorsInMovie(ActorsInMovie aim)
        {
            var res = await client.PutAsJsonAsync("api/ActorsInMovie/UpdateActorsInMovie", aim);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteActorsInMovie(ActorsInMovie aim)
        {
            var res = await client.DeleteAsync($"api/ActorsInMovie/DeleteActorsInMovie{aim.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
    #endregion
        // --------------------------
        #region GENRES IN MOVIES
        // --------------------------
        public async Task<GenresinMoviesList> GetAllGenresInMovies()
        {
            try
            {
                return await client.GetFromJsonAsync<GenresinMoviesList>("api/GenresInMovies/SelectAllGenresInMovies")
                       ?? new GenresinMoviesList();
            }
            catch { return new GenresinMoviesList(); }
        }
        public async Task<GenresinMovies?> GetGenresInMoviesById(int id)
        {
            return await client.GetFromJsonAsync<GenresinMovies>($"api/GenresInMovies/SelectByIdxGenresInMovies{id}");
        }


        public async Task<int> InsertGenresInMovies(GenresinMovies gm)
        {
            var res = await client.PostAsJsonAsync("api/GenresInMovies/InsertGenresInMovies", gm);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateGenresInMovies(GenresinMovies gm)
        {
            var res = await client.PutAsJsonAsync("api/GenresInMovies/UpdateGenresInMovies", gm);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteGenresInMovies(GenresinMovies gm)
        {
            var res = await client.DeleteAsync($"api/GenresInMovies/DeleteGenresInMovies/{gm.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
    #endregion
        // --------------------------
        #region MOVIES
        // --------------------------
        public async Task<MovieList> GetAllMovies()
        {
            try
            {
                return await client.GetFromJsonAsync<MovieList>("api/Movie/SelectAllMovies")
                       ?? new MovieList();
            }
            catch { return new MovieList(); }
        }
        public async Task<Movie?> GetMovieById(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Movie>(
                    $"api/Movie/SelectByIdxMovie{id}"
                );
            }
            catch
            {
                return null;
            }
        }


        public async Task<int> InsertMovie(Movie m)
        {
            var res = await client.PostAsJsonAsync("api/Movie/InsertMovie", m);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovie(Movie m)
        {
            var res = await client.PutAsJsonAsync("api/Movie/UpdateMovie", m);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMovie(Movie m)
        {
            var res = await client.DeleteAsync($"api/Movie/DeleteMovie/{m.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion
        // --------------------------
        #region MOVIE GENRE
        // --------------------------
        public async Task<MovieGenreList> GetAllMovieGenres()
        {
            try
            {
                return await client.GetFromJsonAsync<MovieGenreList>("api/MovieGenre/SelectAllMovieGenres")
                       ?? new MovieGenreList();
            }
            catch { return new MovieGenreList(); }
        }
        public async Task<MovieGenre?> GetMovieGenreById(int id)
        {
            return await client.GetFromJsonAsync<MovieGenre>($"api/MovieGenre/SelectByIdxMovieGenre{id}");
        }

        public async Task<int> InsertMovieGenre(MovieGenre mg)
        {
            var res = await client.PostAsJsonAsync("api/MovieGenre/InsertMovieGenre", mg);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovieGenre(MovieGenre mg)
        {
            var res = await client.PutAsJsonAsync("api/MovieGenre/UpdateMovieGenre", mg);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMovieGenre(MovieGenre mg)
        {
            var res = await client.DeleteAsync($"api/MovieGenre/DeleteMovieGenre/{mg.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
#endregion
        // --------------------------
        #region MOVIE HALL
        // --------------------------
        public async Task<MovieHallList> GetAllMovieHalls()
        {
            try
            {
                return await client.GetFromJsonAsync<MovieHallList>("api/MovieHall/SelectAllMovieHalls")
                       ?? new MovieHallList();
            }
            catch { return new MovieHallList(); }
        }
        public async Task<MovieHall?> GetMovieHallById(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<MovieHall>(
                    $"api/MovieHall/SelectByIdxMovieHall{id}"
                );
            }
            catch
            {
                return null;
            }
        }


        public async Task<int> InsertMovieHall(MovieHall mh)
        {
            var res = await client.PostAsJsonAsync("api/MovieHall/InsertMovieHall", mh);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovieHall(MovieHall mh)
        {
            var res = await client.PutAsJsonAsync("api/MovieHall/UpdateMovieHall", mh);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMovieHall(MovieHall mh)
        {
            var res = await client.DeleteAsync($"api/MovieHall/DeleteMovieHall/{mh.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
#endregion
        // --------------------------
        #region MOVIE SCREENING
        // --------------------------
        public async Task<MovieScreeningList> GetAllMovieScreenings()
        {
            try
            {
                return await client.GetFromJsonAsync<MovieScreeningList>("api/MovieScreening/SelectAllMovieScreenings")
                       ?? new MovieScreeningList();
            }
            catch { return new MovieScreeningList(); }

        }
        public async Task<MovieScreening?> GetMovieScreeningById(int id)
        {
            return await client.GetFromJsonAsync<MovieScreening>($"api/MovieScreening/SelectByIdxMovieScreening{id}");
        }


        public async Task<int> InsertMovieScreening(MovieScreening ms)
        {
            var res = await client.PostAsJsonAsync("api/MovieScreening/InsertMovieScreening", ms);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovieScreening(MovieScreening ms)
        {
            var res = await client.PutAsJsonAsync("api/MovieScreening/UpdateMovieScreening", ms);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMovieScreening(MovieScreening ms)
        {
            var res = await client.DeleteAsync($"api/MovieScreening/DeleteMovieScreening/{ms.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion
        //--------------------------
        #region Ticket
        // --------------------------
        public async Task<TicketList> GetAllTickets()
        {
            try
            {
                return await client.GetFromJsonAsync<TicketList>("api/Ticket/SelectAllTickets")
                       ?? new TicketList();
            }
            catch { return new TicketList(); }
        }
        public async Task<Ticket?> GetTicketById(int id)
        {
            return await client.GetFromJsonAsync<Ticket>($"api/Ticket/SelectByIdxTicket{id}");
        }

        public async Task<int> InsertTicket(Ticket t)
        {
            var res = await client.PostAsJsonAsync("api/Ticket/InsertTicket", t);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateTicket(Ticket t)
        {
            var res = await client.PutAsJsonAsync("api/Ticket/UpdateTicket", t);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteTicket(Ticket t)
        {
            var res = await client.DeleteAsync($"api/Ticket/DeleteTicket/{t.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion
        // --------------------------
        #region  /*THEATER*/
        // --------------------------

        public async Task<TheaterList> GetAllTheaters()
        {
            try
            {
                return await client.GetFromJsonAsync<TheaterList>("api/Theater/SelectAllTheaters")
                       ?? new TheaterList();
            }
            catch { return new TheaterList(); }
        }
        
        public async Task<Theater?> GetTheaterById(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Theater>(
                    $"api/Theater/SelectByIdxTheater{id}"
                );
            }
            catch
            {
                return null;
            }
        }


        public async Task<int> InsertTheater(Theater theater)
        {
            var res = await client.PostAsJsonAsync("api/Theater/InsertTheater", theater);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateTheater(Theater theater)
        {
            var res = await client.PutAsJsonAsync("api/Theater/UpdateTheater", theater);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteTheater(Theater theater)
        {
            var res = await client.DeleteAsync($"api/Theater/DeleteTheater/{theater.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion
        // --------------------------
        #region User
        // --------------------------
        public async Task<UserList> GetAllUsers()
        {
            try
            {
                return await client.GetFromJsonAsync<UserList>("api/User/SelectAllUsers")
                       ?? new UserList();
            }
            catch { return new UserList(); }
        }
        public async Task<User?> GetUserById(int id)
        {
            return await client.GetFromJsonAsync<User>($"api/User/SelectByIdxUser{id}");
        }


        public async Task<int> InsertUser(User user)
        {
            var res = await client.PostAsJsonAsync("api/User/InsertUser", user);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateUser(User user)
        {
            var res = await client.PutAsJsonAsync("api/User/UpdateUser", user);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteUser(User user)
        {
            var res = await client.DeleteAsync($"api/User/DeleteUser/{user.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

    }
}