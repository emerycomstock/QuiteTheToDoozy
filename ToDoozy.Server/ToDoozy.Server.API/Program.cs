using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ToDoozy.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Create in-memory Sqlite connection
var keepAliveConnection = new SqliteConnection("Filename=:memory:");
keepAliveConnection.Open();
builder.Services.AddSingleton(keepAliveConnection);
builder.Services.AddDbContext<ToDoozyDbContext>(options =>
{
    options.UseSqlite(keepAliveConnection);
});

// Add built-in AuthN/AuthZ services with JWT
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddIdentityCore<IdentityUser<int>>()
    .AddEntityFrameworkStores<ToDoozyDbContext>()
    .AddApiEndpoints();

// TODO: Add ToDo service once it's created -> builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Ensure the database schema is automatically built on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ToDoozyDbContext>();
    dbContext.Database.EnsureCreated();
}

// Use default routing middleware
app.UseRouting();
// Use default HTTPS redirect middleware
app.UseHttpsRedirection();
// Use default AuthN/AuthZ middleware
app.UseAuthentication();
app.UseAuthorization();

// Map default handlers for /refresh /login /register
app.MapIdentityApi<IdentityUser<int>>();

// Map ToDo handlers (require auth)
app.MapGet("/todo", ToDoHandlers.ListToDos).WithName("ListToDos").RequireAuthorization();
app.MapGet("/todo/{id}", ToDoHandlers.GetToDoById).WithName("GetToDo").RequireAuthorization();
app.MapPost("/todo", ToDoHandlers.CreateToDo).WithName("CreateToDo").RequireAuthorization();
app.MapPatch("/todo/{id}", ToDoHandlers.UpdateToDo).WithName("UpdateToDo").RequireAuthorization();
app.MapDelete("/todo/{id}", ToDoHandlers.DeleteToDo).WithName("DeleteToDo").RequireAuthorization();

app.Run();
