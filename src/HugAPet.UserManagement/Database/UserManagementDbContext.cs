using HugAPet.UserManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HugAPet.UserManagement.Database;

public class UserManagementDbContext : DbContext
{
    
    public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserProfile> UserProfiles { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasOne<UserProfile>(u => u.UserProfile)
            .WithOne(up => up.User)
            .HasForeignKey<UserProfile>(up => up.UserId);
        
        modelBuilder.Entity<UserProfile>()
            .ToTable("UserProfiles")
            .HasKey(up => up.UserId);
        
    }

}