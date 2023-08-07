using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using POS_Blagajna_Backend.DTOs.IdentityDTOs;
using POS_Blagajna_Backend.Entities.Identity;
using POS_Blagajna_Backend.Interfaces.IdentityInterfaces;

namespace POS_Blagajna_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;     
        }
        public async Task<bool> Register(RegisterUserDTO registerUserDTO)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = registerUserDTO.Username,
            };


            return await _userRepository.Register(user, registerUserDTO.Password);
        }
    }
}