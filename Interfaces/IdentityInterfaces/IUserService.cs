using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.IdentityDTOs;

namespace POS_Blagajna_Backend.Interfaces.IdentityInterfaces
{
    public interface IUserService
    {
        Task<bool> Register(RegisterUserDTO registerUserDTO);
        Task<bool> Login(LoginUserDTO loginUserDTO);
    }
}