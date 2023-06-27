using Microsoft.EntityFrameworkCore;
using TA.Domain.DTOs;
using TA.Domain.Models;
using TA.Domain.Services.DbContexts;

namespace TA.Domain.Services.Validation
{
    public class TodoIdValidator : ITodoIdValidator
    {
        private readonly TodoAppDbContextFactory _dbContextFactory;

        public TodoIdValidator(TodoAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Todo> GetConflictingTodo(Todo todo)
        {
            using (TodoAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return ToTodo(await context.Todos.FirstOrDefaultAsync(t => t.Id == todo.Id));
            }
        }

        private Todo ToTodo(TodoDTO dto)
        {
            if(dto != null)
            {
                return new Todo(dto.Id, dto.Title, dto.Description, dto.Created, dto.Due, dto.IsUrgent, dto.IsComplete);
            }
            return null;
        }
    }
}
