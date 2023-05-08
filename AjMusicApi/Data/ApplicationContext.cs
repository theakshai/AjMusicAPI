using Microsoft.EntityFrameworkCore;
using AjMusicApi.Models;
namespace AjMusicApi.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Artists> Artists { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Auth> Auth { get; set; }

    }
}
