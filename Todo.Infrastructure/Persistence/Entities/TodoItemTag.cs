using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Infrastructure.Persistence.Entities
{
    public class TodoItemTag
    {
        public Guid Id { get; set; }
        public Guid TodoItemId { get; set; }
        public TodoItem TodoItem { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
