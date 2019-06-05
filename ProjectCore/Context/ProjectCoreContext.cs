using System.Xml.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Models;

namespace ProjectCore.Context
{
    public class ProjectCoreContext : IdentityDbContext
    {
        public ProjectCoreContext(DbContextOptions options) : base(options)
        {
          
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.ProjectCore.db");
        }
        
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>().ToTable("AspNetUsers");
        }
    }
}