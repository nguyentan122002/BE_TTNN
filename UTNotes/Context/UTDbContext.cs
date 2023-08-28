using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using UTNotes.Models;

namespace UTNotes.Context

{
    public class UTDbContext :DbContext
    {
        public UTDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Notes> Notes { get; set; }
    }
}
