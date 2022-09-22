using backend.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace backend.Context
{
    public class ConexaoMySQL : DbContext
    {
        readonly MySqlConnectionStringBuilder cs = new()
        {
            Server = "localhost",
            Database = "dbo",
            UserID = "root",
            Password = "P@ssw0rd"
        };

        //public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Filmes> Filmes { get; set; }
        //public DbSet<Locacoes> Locacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(cs.ConnectionString, ServerVersion.AutoDetect(cs.ConnectionString));
    }
}