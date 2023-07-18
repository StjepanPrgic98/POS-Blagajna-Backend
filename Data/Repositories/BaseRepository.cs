using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly DataContext _context;
        protected readonly IdentityDataContext _identityContext;
        public BaseRepository(DataContext context, IdentityDataContext identityContext)
        {
            _identityContext = identityContext;
            _context = context;
        }
    }
}