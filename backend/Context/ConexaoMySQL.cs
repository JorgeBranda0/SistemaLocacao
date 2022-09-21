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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySQL(cs.ConnectionString);
    }
}