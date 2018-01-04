using Microsoft.EntityFrameworkCore;
using SmcLibrary.Core.Models;

namespace SmcLibrary.Persistence
{
    public class LibraryDataContext : DbContext
    {
        public DbSet<Patron> Patrons { get; set; }
        
        public LibraryDataContext(DbContextOptions<LibraryDataContext> options)
            : base(options) { }
    }
}