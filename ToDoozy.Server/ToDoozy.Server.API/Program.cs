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

// HTTPS Redirect Middleware
app.UseHttpsRedirection();

// Map user/auth handlers
app.MapPost("/user", UserHandlers.CreateUser).WithName("CreateUser");
app.MapPost("/login", UserHandlers.Login).WithName("Login");

// Map ToDo handlers
app.MapGet("/todo", ToDoHandlers.ListToDos).WithName("ListToDos");
app.MapGet("/todo/{id}", ToDoHandlers.GetToDoById).WithName("GetToDo");
app.MapPost("/todo", ToDoHandlers.CreateToDo).WithName("CreateToDo");
app.MapPatch("/todo/{id}", ToDoHandlers.UpdateToDo).WithName("UpdateToDo");
app.MapDelete("/todo/{id}", ToDoHandlers.DeleteToDo).WithName("DeleteToDo");

app.Run();
