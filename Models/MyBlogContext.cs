using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APS.net_Entity_.Models
{
    public class MyBlogContext : IdentityDbContext<AppUser>
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach(var entityTyle in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityTyle.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityTyle.SetTableName(tableName.Substring(6));
                }
            }
        }

        public DbSet<Article> articles {  get; set; }
    }
}
