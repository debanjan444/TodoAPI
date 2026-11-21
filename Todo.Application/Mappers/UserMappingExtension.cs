using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.DTOs.Request;
using Todo.Domain.DomainEntities;

namespace Todo.Application.Mappers
{
    public class UserMappingExtension : Profile
    {
        public UserMappingExtension() {

            CreateMap<CreateUserDto, UserDomain>().ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}
