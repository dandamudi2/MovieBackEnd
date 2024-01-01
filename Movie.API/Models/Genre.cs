namespace Movie.API.Models
{
    public class Genre
    {

        public Guid Id { get; set; }

        public string GenreName { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
