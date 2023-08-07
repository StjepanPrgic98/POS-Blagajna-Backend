using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using POS_Blagajna_Backend.Entities.Identity;
using POS_Blagajna_Backend.Interfaces.IdentityInterfaces;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class UserRepository :BaseRepository, IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(DataContext context, UserManager<IdentityUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<bool> Register(IdentityUser user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<IdentityUser> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);        
        }

        public async Task<bool> CheckPassword(IdentityUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}