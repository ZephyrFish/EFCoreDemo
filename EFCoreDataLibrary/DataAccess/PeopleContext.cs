using EFCoreDataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDataLibrary.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext()
        {

        }
        public PeopleContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCoreTest;Trusted_Connection=True;");
        }
    }
}