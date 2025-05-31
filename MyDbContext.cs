using Microsoft.EntityFrameworkCore;

namespace evanbuildsworldsAPI
{
    public class MyDbContext : DbContext
    {
        //Need to add table schema? Reserach details
        //need to add connection string


        //constuctor
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<BlogPost> BlogPost { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().ToTable("blog_post");
        }
    }
}
