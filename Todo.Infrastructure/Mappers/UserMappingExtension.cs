using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.DomainEntities;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Infrastructure.Mappers
{
    public class UserMappingExtension :Profile
    {
        public UserMappingExtension()
        {
            CreateMap<User, UserDomain>().ReverseMap();
        }
    }
}
