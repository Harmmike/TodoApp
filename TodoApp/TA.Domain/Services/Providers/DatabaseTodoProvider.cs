using Microsoft.EntityFrameworkCore;
using TA.Domain.DTOs;
using TA.Domain.Models;
using TA.Domain.Services.DbContexts;

namespace TA.Domain.Services.Providers
{
    public class DatabaseTodoProvider : ITodoProvider
    {
        private readonly TodoAppDbContextFactory _dbContextFactory;

        public DatabaseTodoProvider(TodoAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            using (TodoAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<TodoDTO> todoDTOs = await context.Todos.ToListAsync();
                return todoDTOs.Select(t => new Todo(t.Id, t.Title, t.Description, t.Created, t.Due, t.IsUrgent, t.IsComplete));
            }
        }

        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            using(TodoAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                List<TodoDTO> todos = await context.Todos.ToListAsync();
                TodoDTO dto = todos.FirstOrDefault(t => t.Id == id);
                return new Todo(dto.Id, dto.Title, dto.Description, dto.Created, dto.Due, dto.IsUrgent, dto.IsComplete);
            }
        }
    }
}
