namespace Movie.API.Models
{
    public class ReviewAndRating
    {
        public int Id { get; set; }

        public Movies Movie { get; set; }

        public string UserName { get; set; }

        public string Review { get; set; }

        public string Rating { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
