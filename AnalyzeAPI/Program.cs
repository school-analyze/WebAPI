using AnalyzeAPI;
using AnalyzeAPI.Data;
using AnalyzeAPI.Endpoints;
using AnalyzeAPI.Models;
using AnalyzeAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnalyzeAPI", Version = "v1" }); });

var connectionString = builder.Configuration.GetConnectionString("StudentGrades") ?? "Data Source=StudentGrades.db";
builder.Services.AddSqlite<AppDbContext>(connectionString);

builder.Services.AddIdentity<UserModel, IdentityRole<int>>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<UserModel>();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnalyzeAPI v1"));
app.MapSwagger().RequireAuthorization();

GradeEndpoints.MapEndpoints(app);
UserEndpoints.MapEndpoints(app);

app.Run();