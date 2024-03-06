namespace HugAPet.UserManagement.UserManagement.Database;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public virtual UserProfile UserProfile { get; set; }
}

public enum UserRole
{
    Admin,
    User
}

public class UserProfile
{
    public Guid UserId { get; set; }
    public string? Bio { get; set; }
    public string? Location { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? TwitterHandle { get; set; }
    public string? FacebookProfileUrl { get; set; }
    public string? LinkedInProfileUrl { get; set; }
    public string? InstagramProfileUrl { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime? LastUpdated { get; set; }
    public virtual User User { get; set; }
}

