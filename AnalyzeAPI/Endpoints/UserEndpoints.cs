using AnalyzeAPI.Models;
using AnalyzeAPI.Services;

namespace AnalyzeAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapGet("/users", async (IUserService userService) => await userService.GetAllUsers()); 
        app.MapGet("/users/{id}", async (IUserService userService, int id) => await userService.GetUserById(id));
        app.MapGet("/users/{id}/grades", async (IUserService userService, int id) => await userService.GetUserGrades(id));
        app.MapPost("/users/add", async (IUserService userService, UserModel user) => {
            var newUser = await userService.AddUser(user);
            return Results.Created($"/users/{newUser.Id}", newUser);
        });
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