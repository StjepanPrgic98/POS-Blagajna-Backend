using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.Entities.Identity;

namespace POS_Blagajna_Backend.Interfaces.IdentityInterfaces
{
    public interface IUserRepository
    {
        Task<bool> Register(AppUser user);
    }
}