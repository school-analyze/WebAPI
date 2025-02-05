using AnalyzeAPI.Models;
using AnalyzeAPI.Services;
using Microsoft.AspNetCore.Identity;

namespace AnalyzeAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPost("/users/register", async (UserManager<UserModel> userManager, RegisterViewModel registerModel) => {
            if (string.IsNullOrEmpty(registerModel.Username) || string.IsNullOrEmpty(registerModel.Password))
            {
                return Results.BadRequest("Username and password are required.");
            }
            var user = new UserModel
            {
                UserName = registerModel.Username,
                IsAdmin = false
            };
            var result = await userManager.CreateAsync(user, registerModel.Password);
            return result.Succeeded ? Results.Created($"/users/{user.Id}", user) : Results.BadRequest(
                result.Errors.Select(e => e.Description));
        });
        
        app.MapGet("/users", async (IUserService userService) => await userService.GetAllUsers()); 
        app.MapGet("/users/{id}", async (IUserService userService, int id) => await userService.GetUserById(id));
        app.MapGet("/users/{id}/grades", async (IUserService userService, int id) => await userService.GetUserGrades(id));
        app.MapDelete("/users/delete/{id}", async (IUserService userService, int id) => {
            var user = await userService.GetUserById(id);
            if (user == null)
            {
                return Results.NotFound();
            }
            
            await userService.DeleteUser(user);
            return Results.NoContent();
        });
        app.MapPut("/users/update/{id}", async (IUserService userService, int id, UserModel newUser) => {
            var user = await userService.GetUserById(id);
            if (user == null)
            {
                return Results.NotFound();
            }
            
            await userService.UpdateUser(id, newUser);
            return Results.Ok(newUser);
        });
    }
}