using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace POS_Blagajna_Backend.Entities.Identity
{
    public class AppUserRole
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}