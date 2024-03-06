using HugAPet.UserManagement.Shared;
using HugAPet.UserManagement.UserManagement.Database;
using Wolverine;

namespace HugAPet.UserManagement.UserManagement.RegisterUser;

public record RegisterUser(
    string Username, 
    string Email,
    string FirstName,
    string LastName,
    DateTime? DateOfBirth);

public class RegisterUserHandler(UserManagementDbContext dbContext)
{
    public Guid Handle(RegisterUser command)
    {
        var user = new User
        {
            Username = command.Username,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            DateOfBirth = command.DateOfBirth?.ToUniversalTime(),
            Role = UserRole.User
        };
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        
        var userProfile = new UserProfile
        {
            UserId = user.Id
        };
        dbContext.UserProfiles.Add(userProfile);
        dbContext.SaveChanges();
        return user.Id;
    }
}

public class RegisterUserEndpoint : IEndpoint
{
    public void Register(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/issues/create", (RegisterUser body, IMessageBus bus) => bus.InvokeAsync(body));
    }
}
