namespace AnalyzeAPI;

public class ProgramEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
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
    }
}