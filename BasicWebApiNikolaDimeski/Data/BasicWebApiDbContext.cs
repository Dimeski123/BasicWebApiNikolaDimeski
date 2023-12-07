using Microsoft.EntityFrameworkCore;
using BasicWebApiNikolaDimeski.Models;

namespace BasicWebApiNikolaDimeski.Data
{
    public class BasicWebApiDbContext : DbContext
    {
        public BasicWebApiDbContext(DbContextOptions<BasicWebApiDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Country> Countries { get; set; }


    }

}

