using System;
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
        public DbSet<Task> Task { get; set; }
        public DbSet<TaskType> TaskType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            
            // Wstępnie wypełnienie tabeli z typami zadań

            modelBuilder.Entity<TaskType>()
                .HasData(
                    new TaskType()
                        {DateOfCreation = DateTime.Now, DateOfUpdate = DateTime.Now, Id = 1, name = "Support"},
                    new TaskType()
                        {DateOfCreation = DateTime.Now, DateOfUpdate = DateTime.Now, Id = 2, name = "Subtask"},
                    new TaskType()
                        {DateOfCreation = DateTime.Now, DateOfUpdate = DateTime.Now, Id = 3, name = "Task"},
                    new TaskType()
                        {DateOfCreation = DateTime.Now, DateOfUpdate = DateTime.Now, Id = 4, name = "Epic"}
                );
        }
    }
}