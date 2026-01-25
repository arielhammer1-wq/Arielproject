    using System.Diagnostics;
    using System.Net.Http.Json;
    using Model;
    using Myservice;

    namespace ApiInterface
    {
        public class ApiService : IApiService
    {
            private readonly string baseUrl = "https://9qqdvhpm-5096.euw.devtunnels.ms/";
            private readonly HttpClient client;

            public ApiService()
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                
            }

        // --------------------------
        // CITY
        // --------------------------
        public async Task<CityList> GetAllCities()
        {
            try
            {
                return await client.GetFromJsonAsync<CityList>("api/City/GetAll/SelectAllCities")
                       ?? new CityList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllCities: {ex.Message}");
            }
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
            var res = await client.DeleteAsync($"api/City/DeleteCity{city.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }


        // --------------------------
        // CUSTOMER
        // --------------------------
        public async Task<CustomerList> GetAllCustomers()
        {
            try
            {
                return await client.GetFromJsonAsync<CustomerList>( "Customer/SelectAllCustomers")
                       ?? new CustomerList();
            }
            catch { return new CustomerList(); }
        }

        public async Task<int> InsertCustomer(Customer c)
        {
            var res = await client.PostAsJsonAsync( "Customer/InsertCustomer", c);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCustomer(Customer c)
        {
            var res = await client.PutAsJsonAsync( "Customer/UpdateCustomer", c);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteCustomer(Customer c)
        {
            var res = await client.DeleteAsync( $"Customer/DeleteCustomer{c.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // GENDER
        // --------------------------
        public async Task<GenderList> GetAllGenders()
        {
            try
            {
                return await client.GetFromJsonAsync<GenderList>( "Gender/SelectAllGenders")
                       ?? new GenderList();
            }
            catch { return new GenderList(); }
        }

        public async Task<int> InsertGender(Gender g)
        {
            var res = await client.PostAsJsonAsync( "Gender/InsertGender", g);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateGender(Gender g)
        {
            var res = await client.PutAsJsonAsync( "Gender/UpdateGender", g);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteGender(Gender g)
        {
            var res = await client.DeleteAsync( $"Gender/DeleteGender{g.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // ROLE
        // --------------------------
        public async Task<RoleList> GetAllRoles()
        {
            try
            {
                return await client.GetFromJsonAsync<RoleList>( "Role/SelectAllRoles")
                       ?? new RoleList();
            }
            catch { return new RoleList(); }
        }

        public async Task<int> InsertRole(Role role)
        {
            var res = await client.PostAsJsonAsync( "Role/InsertRole", role);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateRole(Role role)
        {
            var res = await client.PutAsJsonAsync( "Role/UpdateRole", role);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteRole(Role role)
        {
            var res = await client.DeleteAsync( $"Role/DeleteRole{role.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // OPERATOR
        // --------------------------
        public async Task<OperatorList> GetAllOperators()
        {
            try
            {
                return await client.GetFromJsonAsync<OperatorList>("Operator/SelectAllOperators")
                       ?? new OperatorList();
            }
            catch { return new OperatorList(); }
        }

        public async Task<int> InsertOperator(Operator op)
        {
            var res = await client.PostAsJsonAsync( "Operator/InsertOperator", op);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateOperator(Operator op)
        {
            var res = await client.PutAsJsonAsync( "Operator/UpdateOperator", op);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteOperator(Operator op)
        {
            var res = await client.DeleteAsync( $"Operator/DeleteOperator{op.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // ARTIST
        // --------------------------
        public async Task<ArtistList> GetAllArtists()
        {
            try
            {
                return await client.GetFromJsonAsync<ArtistList>( "Artist/SelectAllArtists")
                       ?? new ArtistList();
            }
            catch { return new ArtistList(); }
        }

        public async Task<int> InsertArtist(Artist a)
        {
            var res = await client.PostAsJsonAsync( "Artist/InsertArtist", a);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateArtist(Artist a)
        {
            var res = await client.PutAsJsonAsync( "Artist/UpdateArtist", a);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteArtist(Artist a)
        {
            var res = await client.DeleteAsync( $"Artist/DeleteArtist{a.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // ACTORS IN MOVIE
        // --------------------------
        public async Task<ActorsInMovieList> GetAllActorsInMovies()
        {
            try
            {
                return await client.GetFromJsonAsync<ActorsInMovieList>( "ActorsInMovie/SelectAllActorsInMovies")
                       ?? new ActorsInMovieList();
            }
            catch { return new ActorsInMovieList(); }
        }

        public async Task<int> InsertActorsInMovie(ActorsInMovie aim)
        {
            var res = await client.PostAsJsonAsync( "ActorsInMovie/InsertActorsInMovie", aim);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateActorsInMovie(ActorsInMovie aim)
        {
            var res = await client.PutAsJsonAsync( "ActorsInMovie/UpdateActorsInMovie", aim);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteActorsInMovie(ActorsInMovie aim)
        {
            var res = await client.DeleteAsync( $"ActorsInMovie/DeleteActorsInMovie{aim.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // GENRES IN MOVIES
        // --------------------------
        public async Task<GenresinMoviesList> GetAllGenresInMovies()
        {
            try
            {
                return await client.GetFromJsonAsync<GenresinMoviesList>( "GenresInMovies/SelectAllGenresInMovies")
                       ?? new GenresinMoviesList();
            }
            catch { return new GenresinMoviesList(); }
        }

        public async Task<int> InsertGenresInMovies(GenresinMovies gm)
        {
            var res = await client.PostAsJsonAsync( "GenresInMovies/InsertGenresInMovies", gm);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateGenresInMovies(GenresinMovies gm)
        {
            var res = await client.PutAsJsonAsync( "GenresInMovies/UpdateGenresInMovies", gm);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteGenresInMovies(GenresinMovies gm)
        {
            var res = await client.DeleteAsync( $"GenresInMovies/DeleteGenresInMovies{gm.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // MOVIES
        // --------------------------
        public async Task<MovieList> GetAllMovies()
        {
            try
            {
                return await client.GetFromJsonAsync<MovieList>( "Movie/SelectAllMovies")
                       ?? new MovieList();
            }
            catch { return new MovieList(); }
        }

        public async Task<int> InsertMovie(Movie m)
        {
            var res = await client.PostAsJsonAsync( "Movie/InsertMovie", m);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovie(Movie m)
        {
            var res = await client.PutAsJsonAsync( "Movie/UpdateMovie", m);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMovie(Movie m)
        {
            var res = await client.DeleteAsync( $"Movie/DeleteMovie{m.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // MOVIE GENRE
        // --------------------------
        public async Task<MovieGenreList> GetAllMovieGenres()
        {
            try
            {
                return await client.GetFromJsonAsync<MovieGenreList>( "MovieGenre/SelectAllMovieGenres")
                       ?? new MovieGenreList();
            }
            catch { return new MovieGenreList(); }
        }

        public async Task<int> InsertMovieGenre(MovieGenre mg)
        {
            var res = await client.PostAsJsonAsync( "MovieGenre/InsertMovieGenre", mg);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovieGenre(MovieGenre mg)
        {
            var res = await client.PutAsJsonAsync( "MovieGenre/UpdateMovieGenre", mg);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMovieGenre(MovieGenre mg)
        {
            var res = await client.DeleteAsync( $"MovieGenre/DeleteMovieGenre{mg.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // MOVIE HALL
        // --------------------------
        public async Task<MovieHallList> GetAllMovieHalls()
        {
            try
            {
                return await client.GetFromJsonAsync<MovieHallList>( "MovieHall/SelectAllMovieHalls")
                       ?? new MovieHallList();
            }
            catch { return new MovieHallList(); }
        }

        public async Task<int> InsertMovieHall(MovieHall mh)
        {
            var res = await client.PostAsJsonAsync( "MovieHall/InsertMovieHall", mh);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovieHall(MovieHall mh)
        {
            var res = await client.PutAsJsonAsync( "MovieHall/UpdateMovieHall", mh);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMovieHall(MovieHall mh)
        {
            var res = await client.DeleteAsync( $"MovieHall/DeleteMovieHall{mh.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // MOVIE SCREENING
        // --------------------------
        public async Task<MovieScreeningList> GetAllMovieScreenings()
        {
            try
            {
                return await client.GetFromJsonAsync<MovieScreeningList>( "MovieScreening/SelectAllMovieScreenings")
                       ?? new MovieScreeningList();
            }
            catch { return new MovieScreeningList(); }
        }

        public async Task<int> InsertMovieScreening(MovieScreening ms)
        {
            var res = await client.PostAsJsonAsync( "MovieScreening/InsertMovieScreening", ms);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovieScreening(MovieScreening ms)
        {
            var res = await client.PutAsJsonAsync( "MovieScreening/UpdateMovieScreening", ms);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMovieScreening(MovieScreening ms)
        {
            var res = await client.DeleteAsync( $"MovieScreening/DeleteMovieScreening{ms.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        // --------------------------
        // TICKET
        // --------------------------
        public async Task<TicketList> GetAllTickets()
        {
            try
            {
                return await client.GetFromJsonAsync<TicketList>( "Ticket/SelectAllTickets")
                       ?? new TicketList();
            }
            catch { return new TicketList(); }
        }

        public async Task<int> InsertTicket(Ticket t)
        {
            var res = await client.PostAsJsonAsync( "Ticket/InsertTicket", t);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateTicket(Ticket t)
        {
            var res = await client.PutAsJsonAsync( "Ticket/UpdateTicket", t);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteTicket(Ticket t)
        {
            var res = await client.DeleteAsync( $"Ticket/DeleteTicket{t.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }
        // --------------------------
        // THEATER
        // --------------------------
        public async Task<TheaterList> GetAllTheaters()
        {
            try
            {
                return await client.GetFromJsonAsync<TheaterList>( "Theater/SelectAllTheaters")
                       ?? new TheaterList();
            }
            catch { return new TheaterList(); }
        }

        public async Task<int> InsertTheater(Theater theater)
        {
            var res = await client.PostAsJsonAsync( "Theater/InsertTheater", theater);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateTheater(Theater theater)
        {
            var res = await client.PutAsJsonAsync( "Theater/UpdateTheater", theater);
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteTheater(Theater theater)
        {
            var res = await client.DeleteAsync( $"Theater/DeleteTheater{theater.Id}");
            return res.IsSuccessStatusCode ? 1 : 0;
        }

        }
    }
