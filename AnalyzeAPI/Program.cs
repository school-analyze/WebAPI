using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnalyzeAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnalyzeAPI v1"));

app.MapGet("/", () => "Data Analyze API"); // All marks get
app.MapPost("/marks/add" , (int mark) => {
    return mark;
}); // Add mark
app.MapDelete("/marks/delete/{id}", (int id) => {
    return id;
}); // Delete mark
app.MapPut("/marks/update/{id}", (int id, int mark) => {
    return id + " " + mark;
}); // Update mark

app.MapGet("/users", () => "Users API"); // All users get
app.MapGet("/users/{id}", (int id) => {
    return id;
}); // User get
app.MapPost("/users/add", (string name) => {
    return name;
}); // Add user
app.MapDelete("/users/delete/{id}", (int id) => {
    return id;
}); // Delete user
app.MapPut("/users/update/{id}", (int id, string name) => {
    return id + " " + name;
}); // Update user


app.Run();
