using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieRatingAndReview.Models
{
    public class Casts
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public string ?ImageUrl { get; set; }
        //public IList<MovieCast>? MovieCasts { get; set; }
        //public int MovieId { get; set; }
        //public IList<Movie> ?Movies { get; set; }  

    }
}
