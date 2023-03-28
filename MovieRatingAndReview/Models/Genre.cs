using Microsoft.EntityFrameworkCore;

namespace MovieRatingAndReview.Models
{
    [Keyless]
    public class Genre
    {
        public String ?Type { get; set; }
    }
}
