using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS_Blagajna_Backend.DTOs.IdentityDTOs;
using POS_Blagajna_Backend.Interfaces.IdentityInterfaces;

namespace POS_Blagajna_Backend.Controllers.IdentityControllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;     
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO registerUserDTO)
        {
            return await _userService.Register(registerUserDTO);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginUserDTO loginUserDTO)
        {
            return await _userService.Login(loginUserDTO);
        }
    }
}