using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace POS_Blagajna_Backend.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public DateTime Created { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}