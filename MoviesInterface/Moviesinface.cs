using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInterface
{
    public interface Moviesinface
    {
    public Task<CityList> GetAllCities();
    public Task<int> InsertACity(City city);
    public Task<int> UpdateACity(City city);
    public Task<int> DeleteACity(City city);
    public Task<CustomerList> GetAllCustomers();
    public Task<int> InsertCustomer(Customer customer);
    public Task<int> UpdateCustomer(Customer customer);
    public Task<int> DeleteCustomer(Customer customer);
    public Task<OperatorList> GetAllOperators();
    public Task<int> InsertOperator(Operator op);
    public Task<int> UpdateOperator(Operator op);
    public Task<int> DeleteOperator(Operator op);
    public Task<RoleList> GetAllRoles();
    public Task<int> InsertRole(Role role);
    public Task<int> UpdateRole(Role role);
    public Task<int> DeleteRole(Role role);
    public Task<GenderList> GetAllGenders();
    public Task<int> InsertGender(Gender gender);
    public Task<int> UpdateGender(Gender gender);
    public Task<int> DeleteGender(Gender gender);
    public Task<TheaterList> GetAllTheaters();
    public Task<int> InsertTheater(Theater theater);
    public Task<int> UpdateTheater(Theater theater);
    public Task<int> DeleteTheater(Theater theater);
    public Task<MovieHallList> GetAllMovieHalls();
    public Task<int> InsertMovieHall(MovieHall hall);
    public Task<int> UpdateMovieHall(MovieHall hall);
    public Task<int> DeleteMovieHall(MovieHall hall);
    public Task<MovieList> GetAllMovies();
    public Task<int> InsertMovie(Movie movie);
    public Task<int> UpdateMovie(Movie movie);
    public Task<int> DeleteMovie(Movie movie);
    public Task<MovieGenreList> GetAllMovieGenres();
    public Task<int> InsertMovieGenre(MovieGenre genre);
    public Task<int> UpdateMovieGenre(MovieGenre genre);
    public Task<int> DeleteMovieGenre(MovieGenre genre);
    public Task<MovieScreeningList> GetAllMovieScreenings();
    public Task<int> InsertMovieScreening(MovieScreening screening);
    public Task<int> UpdateMovieScreening(MovieScreening screening);
    public Task<int> DeleteMovieScreening(MovieScreening screening);
    public Task<TicketList> GetAllTickets();
    public Task<int> InsertTicket(Ticket ticket);
    public Task<int> UpdateTicket(Ticket ticket);
    public Task<int> DeleteTicket(Ticket ticket);
    public Task<ArtistList> GetAllArtists();
    public Task<int> InsertArtist(Artist artist);
    public Task<int> UpdateArtist(Artist artist);
    public Task<int> DeleteArtist(Artist artist);
    public Task<ActorsInMovieList> GetAllActorsInMovies();
    public Task<int> InsertActorsInMovie(ActorsInMovie aim);
    public Task<int> UpdateActorsInMovie(ActorsInMovie aim);
    public Task<int> DeleteActorsInMovie(ActorsInMovie aim);
    public Task<GenresinMoviesList> GetAllGenresInMovies();
    public Task<int> InsertGenresInMovies(GenresinMovies gm);
    public Task<int> UpdateGenresInMovies(GenresinMovies gm);
    public Task<int> DeleteGenresInMovies(GenresinMovies gm);
}
}
