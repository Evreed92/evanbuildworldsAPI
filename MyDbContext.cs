using evanbuildsworldsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace evanbuildsworldsAPI
{
    public class MyDbContext : DbContext
    {
        //Need to add table schema? Reserach details
        //need to add connection string

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleType> ArticleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article >().ToTable("articles");
            modelBuilder.Entity<ArticleType>().ToTable("types");
        }
    }
}
