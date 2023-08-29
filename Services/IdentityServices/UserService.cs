using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POS_Blagajna_Backend.DTOs.IdentityDTOs;
using POS_Blagajna_Backend.Entities.Identity;
using POS_Blagajna_Backend.Interfaces.IdentityInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;     
        }

        public async Task<UserDTO> Register(RegisterUserDTO registerUserDTO)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = registerUserDTO.Username,
                Email = registerUserDTO.Email
            };


            await _userRepository.Register(user, registerUserDTO.Password);

            string tokenString = _tokenService.GenerateToken(user);

            return new UserDTO
            {
                Username = user.UserName,
                TokenString = tokenString
            };
        }

        public async Task<UserDTO> Login(LoginUserDTO loginUserDTO)
        {
            IdentityUser user = await _userRepository.GetUserByEmail(loginUserDTO.Email);

            string tokenString = _tokenService.GenerateToken(user);
            
            
            if(user == null){return null;}

            if(!await _userRepository.CheckPassword(user, loginUserDTO.Password)){return null;}

            return new UserDTO
            {
                Username = user.UserName,
                TokenString = tokenString
            };
        }
    }
}