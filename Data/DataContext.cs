using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
    }
}