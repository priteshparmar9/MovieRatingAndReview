﻿namespace MovieRatingAndReview.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string ?UserName { get; set; }
        public string ?Password { get; set; }
        public string ?Email { get; set; }
        //public IList<Review> ?Reviews { get; set; }
    }
}
