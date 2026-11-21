using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts;
using Todo.Application.DTOs.Request;
using Todo.Domain.DomainEntities;
using Todo.Domain.RepositoryInterface;

namespace Todo.Application.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<bool> CreateUserAsync(CreateUserDto userDto)
        {

           var userDomain =  _mapper.Map<UserDomain>(userDto);
           userDomain.PasswordHash =   BCrypt.Net.BCrypt.HashPassword(userDomain.PasswordHash);


            await _userRepository.AddAsync(userDomain);


            var response = await _userRepository.CommitAsync();

            return response > 0;

        }
    }
}
