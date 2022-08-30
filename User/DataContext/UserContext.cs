using Microsoft.EntityFrameworkCore;
using User.Model;
namespace User.DataContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        { }
                    public DbSet<Model.User> Users { get; set; }
                    public DbSet<Model.Role> Roles { get; set; }
    }
    }



