using HugAPet.UserManagement.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserManagementDbContext>(o =>
{
    o.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        builder.Configuration.Bind("JwtSettings", options);
        
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

builder.Services.AddClientCredentialsTokenManagement()
    .AddClient("auth.service.client", client =>
    {
        builder.Configuration.Bind("AuthSettings", client);
        client.Scope = "auth.service";
    });
builder.Services.AddClientCredentialsHttpClient("auth.service", "auth.service.client", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["JwtSettings:Authority"] + "/api");
});


var app = builder.Build();
SeedData.EnsureSeedData(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.Run();

