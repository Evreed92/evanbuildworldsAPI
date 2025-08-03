using evanbuildsworldsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace evanbuildsworldsAPI
{
    public class MyDbContext : DbContext
    {
        //Need to add table schema? Reserach details
        //need to add connection string


        //constuctor
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Article> Article { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article >().ToTable("article");
        }
    }
}
