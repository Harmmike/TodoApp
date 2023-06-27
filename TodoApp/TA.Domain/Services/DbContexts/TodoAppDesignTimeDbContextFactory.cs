
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TA.Domain.Services.DbContexts
{
    public class TodoAppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoAppDbContext>
    {
        public TodoAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=todoapp.db").Options;
            return new TodoAppDbContext(options);
        }
    }
}
