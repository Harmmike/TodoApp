using Microsoft.EntityFrameworkCore;

namespace TA.Domain.Services.DbContexts
{
    public class TodoAppDbContextFactory
    {
        private readonly string _connectionString;

        public TodoAppDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TodoAppDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new TodoAppDbContext(options);
        }
    }
}
