using Microsoft.EntityFrameworkCore;
using TA.Domain.DTOs;

namespace TA.Domain.Services.DbContexts
{
    public class TodoAppDbContext : DbContext
    {
        public DbSet<TodoDTO> Todos { get; set; }

        public TodoAppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
