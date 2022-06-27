using Microsoft.EntityFrameworkCore;

namespace CRUD_TokenLab.Models
{
    public class LoginContext:DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options):base(options)
        {
                
        }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
