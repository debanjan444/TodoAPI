using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.DomainEntities
{
    public class TodoListDomain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TodoItemDomain> TodoItems { get; set; }
        public Guid UserId { get; set; }
        public UserDomain User { get; set; }
    }
}
