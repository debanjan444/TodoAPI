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


    // TodoListDomain -> TodoResponseDto
    public static TodoResponseDto ToResponseDto(this TodoListDomain source)
    {
        return new TodoResponseDto(
            Name: source.Name,
            Description: source.Description,
            Metadata: source.TodoItems
                .Select(item => item.ToMetadata())
                .ToList()
        );
    }

    // TodoItemDomain -> TodoMetadata
    public static TodoMetadata ToMetadata(this TodoItemDomain source)
    {
        return new TodoMetadata(
            Title: source.Title,
            Description: source.Description,
            Priority: source.Priority.ToString(),
            Status: source.Status.ToString(),
            DueDate: source.DueDate
        );
    }

    // IEnumerable<TodoListDomain> -> List<TodoResponseDto>
    public static List<TodoResponseDto> ToResponseDtos(
        this IEnumerable<TodoListDomain> source)
    {
        return source.Select(todo => todo.ToResponseDto()).ToList();
    }





}