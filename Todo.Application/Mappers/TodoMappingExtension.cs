using Todo.Application.DTOs.Request;
using Todo.Application.DTOs.Response;
using Todo.Domain.DomainEntities;

namespace Todo.Application.Mappers;

public static class TodoMappingExtension
{
    public  static TodoListDomain ConvertToTodoListDomain(this CreateTodoDto todo)
    {
        return new TodoListDomain()
        {
            Description = todo.description,
            Name = todo.name,
            TodoItems = todo.Items.Select(x => new TodoItemDomain()
            {
                Description = x.description,
                Title = x.title,
                Priority = x.priority,
                DueDate = x.dueDate,
                ReminderDate = x.remiderDate,
            })
            .ToList()
        };
    }
}