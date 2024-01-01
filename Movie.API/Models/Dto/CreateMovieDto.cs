namespace Movie.API.Models.Dto
{
    public class CreateMovieDto
    {

        public string MovieName { get; set; }

        public string Language { get; set; }

        public string Image { get; set; }

        public int GenreId { get; set; }

        public DateTime CreatedDt { get; set; }


    }
}
