using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS_Blagajna_Backend.DTOs.IdentityDTOs;

namespace POS_Blagajna_Backend.Interfaces.IdentityInterfaces
{
    public interface IUserService
    {
        Task<UserDTO> Register(RegisterUserDTO registerUserDTO);
        Task<UserDTO> Login(LoginUserDTO loginUserDTO);
    }
}