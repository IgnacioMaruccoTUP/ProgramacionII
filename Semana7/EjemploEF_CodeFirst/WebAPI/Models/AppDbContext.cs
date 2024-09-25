using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Navigation(e => e.Rol).AutoInclude();
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
