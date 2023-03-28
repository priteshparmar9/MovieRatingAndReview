using Microsoft.EntityFrameworkCore;
namespace MovieRatingAndReview.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt):base(opt) 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PRITESH-EG2002T\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder
modelBuilder)
        {
        }
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Casts> Casts { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; }
        
    }
}
