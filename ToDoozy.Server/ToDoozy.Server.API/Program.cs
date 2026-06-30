var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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
