using Microsoft.EntityFrameworkCore;
using Core.Model;

namespace RedditCloneAPI.Data
{
    public class RedditCloneContext : DbContext
    {
        public RedditCloneContext(DbContextOptions<RedditCloneContext> options)
            : base(options)
        {
        }

        public DbSet<ThreadPost> Threads { get; set; } 
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}