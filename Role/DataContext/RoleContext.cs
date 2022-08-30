using Microsoft.EntityFrameworkCore;

namespace Role.DataContext
{
    public class RoleContext : DbContext
    {
        public RoleContext(DbContextOptions<RoleContext> options) : base(options)
        { }
                    public DbSet<Model.Role> Roles { get; set; }
    }
    }



