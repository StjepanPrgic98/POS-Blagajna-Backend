using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace POS_Blagajna_Backend.Data
{
    public class IdentityDataContext : IdentityDbContext
    {
        public IdentityDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}