using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace POS_Blagajna_Backend.Interfaces.ServiceInterfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(IdentityUser user);
    }
}