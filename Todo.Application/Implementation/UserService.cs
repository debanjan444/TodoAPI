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
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository,IMapper mapper,IEmailService emailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
        }
        
        public async Task<bool> CreateUserAsync(CreateUserDto userDto)
        {

           var userDomain =  _mapper.Map<UserDomain>(userDto);
           userDomain.PasswordHash =   BCrypt.Net.BCrypt.HashPassword(userDomain.PasswordHash);


            await _userRepository.AddAsync(userDomain);


            var response = await _userRepository.CommitAsync();
            if (response > 0) {
                await _emailService.SendMailAsync(userDomain.Email);
                    };
            return response > 0;

        }
    }
}
