using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ReceiptHeader> ReceiptHeaders { get; set; }
    }
}