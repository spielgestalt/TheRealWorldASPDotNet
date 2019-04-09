using System;
using Microsoft.EntityFrameworkCore;
using TheRealWorldASPDotNet.Models;

namespace TheRealWorldASPDotNet.Services
{
    public class PagesDbContext: DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Content> Contents { get; set; }

        public PagesDbContext(DbContextOptions<PagesDbContext> options): base(options) {
            Database.EnsureCreated();
        }
    }
}
