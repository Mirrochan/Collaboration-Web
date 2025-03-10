using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Models;


namespace Infrastructure
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options) { }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<GroupModel> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<UserModel>()
            //    .HasMany(u => u.Tasks)
            //    .WithOne(t => t.User)
            //    .HasForeignKey(t => t.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Groups)
                .WithMany(g => g.Users)
                ;

            //modelBuilder.Entity<GroupModel>()
            //    .HasMany(g => g.Users)
            //    .WithMany(u => u.Groups)
            //    ;
        }

    }
}
