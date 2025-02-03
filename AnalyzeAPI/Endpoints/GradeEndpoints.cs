using AnalyzeAPI.Models;
using AnalyzeAPI.Services;

namespace AnalyzeAPI.Endpoints;

public static class GradeEndpoints
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
        app.MapPut("/grades/update/{id}", async (IGradeService gradeService, int id, GradeModel newGrade) =>
        {
            var grade = await gradeService.GetGradeById(id);
            if (grade == null)
            {
                return Results.NotFound();
            }
            
            await gradeService.UpdateGrade(id, newGrade);
            return Results.Ok(newGrade);
        });
    }
}