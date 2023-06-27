using Microsoft.EntityFrameworkCore.Internal;
using TA.Domain.DTOs;
using TA.Domain.Models;
using TA.Domain.Services.DbContexts;

namespace TA.Domain.Services.TodoCreators
{
    public class DatabaseTodoCreator : ITodoCreator
    {
        private readonly TodoAppDbContextFactory _dbContextFactory;

        public DatabaseTodoCreator(TodoAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateTodo(Todo todo)
        {
            using (TodoAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                TodoDTO dto = new TodoDTO()
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    Created = todo.Created, 
                    Due = todo.Due,
                    IsUrgent = todo.IsUrgent,
                    IsComplete = todo.IsComplete
                };

                context.Add(dto);
                await context.SaveChangesAsync();
            }
        }
    }
}
