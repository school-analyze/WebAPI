using AnalyzeAPI;
using AnalyzeAPI.Data;
using AnalyzeAPI.Services;
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

var connectionString = builder.Configuration.GetConnectionString("StudentGrades") ?? "Data Source=StudentGrades.db";
builder.Services.AddSqlite<AppDbContext>(connectionString);

builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnalyzeAPI v1"));

ProgramEndpoints.MapEndpoints(app);

app.Run();
