using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRatingAndReview.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string ?Title { get; set; }
        public string ?Review_description { get; set; }
        public int UsersId { get; set; }
        //public Users ?Users { get; set; }
        public int MovieId { get; set; }

    }
}
