using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.API.Models
{
    public class Movies
    {
        public int Id { get; set; }

        public string MovieName { get; set; }

        public string Language { get; set; }

        public string Image { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public Platform Platform { get; set; }

        public DateTime CreatedDt { get; set; }

        public DateTime ModifiedDt { get; set; } 

    }
}
