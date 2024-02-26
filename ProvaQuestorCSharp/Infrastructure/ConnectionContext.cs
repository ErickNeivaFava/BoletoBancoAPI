using Microsoft.EntityFrameworkCore;
using ProvaQuestorCSharp.Domain.Model;

namespace ProvaQuestorCSharp.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext()
        {
            
        }
        public ConnectionContext(DbContextOptions<ConnectionContext> options)
            :base(options)
        {            
        }

        public DbSet<Banco> Banco { get; set; }
        public DbSet<Boleto> Boleto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql(
              "Server=localhost;" +
              "Port=5432;Database=DB_ProvaQuestor;" +
              "User Id=postgres;" +
              "Password=admin;");
    }
}
