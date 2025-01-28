using AnalyzeAPI.Models;
using AnalyzeAPI.Services;

namespace AnalyzeAPI;

public class ProgramEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapGet("/grades", async (IGradeService gradeService) => await gradeService.GetAllGrades());
        app.MapGet("/grades/{id}", async (IGradeService gradeService, int id) => await gradeService.GetGradeById(id));
        app.MapPost("/grades/add", async (IGradeService gradeService, GradeModel grade) => {
            var newGrade = await gradeService.AddGrade(grade);
            return Results.Created($"/grades/{newGrade.Id}", newGrade);
        });
        app.MapDelete("/grades/delete/{id}", async (IGradeService gradeService, int id) =>
        {
            var grade = await gradeService.GetGradeById(id);
            if (grade == null)
            {
                return Results.NotFound();
            }
            
            await gradeService.DeleteGrade(grade);
            return Results.NoContent();
        });
        app.MapPut("/grades/update/{id}", (int id, int grade) => {
            return id + " " + grade;
        }); // Update mark

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
        app.MapPut("/users/update/{id}", (int id, string name) => {
            return id + " " + name;
        }); // Update user
    }
}