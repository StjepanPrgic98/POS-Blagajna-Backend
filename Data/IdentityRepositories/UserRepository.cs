using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.Entities.Identity;
using POS_Blagajna_Backend.Interfaces.IdentityInterfaces;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class UserRepository :BaseRepository, IUserRepository
    {
        public UserRepository(DataContext context, IdentityDataContext identityContext) : base(context, identityContext)
        {
        }

        public async Task<bool> Register(AppUser user)
        {
            _identityContext.Users.Add(user);
            return await _identityContext.SaveChangesAsync() > 0;
        }
    }
}