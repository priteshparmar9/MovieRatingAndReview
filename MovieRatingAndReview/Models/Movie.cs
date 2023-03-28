using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRatingAndReview.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string ?Title { get; set; }
        public string ?Description { get; set; }
        public string ?Type { get; set; }
        public int Duration { get; set; }
        //public IList <MovieCast> ?MovieCasts { get; set; }
        //public ICollection<int> Casts {get; set; }
        public string ?Director { get; set; }
        public string ?Writer { get; set; }
        public string ?Poster { get; set; }
        //public ICollection<Genre> ?Genre { get; set; }
        public string ?Trailer { get; set; }
        [NotMapped]
        public IList<int> ?Reviews { get; set; }


    }
}
