using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using POS_Blagajna_Backend.Entities.Identity;

namespace POS_Blagajna_Backend.Interfaces.IdentityInterfaces
{
    public interface IUserRepository
    {
        Task<bool> Register(IdentityUser user, string password);

        Task<IdentityUser> GetUserByUsername(string username);
        Task<IdentityUser> GetUserByEmail(string email);
        Task<bool> CheckPassword(IdentityUser user, string password);
    }
}