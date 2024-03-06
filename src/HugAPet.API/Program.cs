using HugAPet.UserManagement.Shared;
using HugAPet.UserManagement.UserManagement;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddMessaging();
builder.AddAuthentication();
builder.AddUserManagement();

var app = builder.Build();
app.UseUserManagement();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMessaging();

app.Run();

