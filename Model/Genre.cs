namespace Model
{
    public class MovieGenre : BaseEntity
    {
        public string Genre { get; set; }
        public string GenreValue { get; set; }

        public MovieList Movies { get; set; } = new MovieList();
    }
}
