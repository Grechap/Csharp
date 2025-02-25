using APIDatabase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApiWithDB>(); // Настройкa DbContext

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiWithDB>();
    db.Database.Migrate();
}

app.MapGet("/api/students", async (ApiWithDB db) =>
{
    return await db.Students.ToListAsync();
});

app.MapGet("/api/students/{name}", async (ApiWithDB db, string name) =>
{
    var student = await db.Students.FirstOrDefaultAsync(s => s.FirstName == name);

    if (student == null)
        return Results.NotFound(new { message = "Студента с таким именем нет" });

    return Results.Json(student);
});

app.MapPost("/api/students", async (ApiWithDB db, Students student) =>
{
    if (student == null)
{
        return Results.BadRequest(new { message = "Данные студента не могут быть пустыми" });
}

db.Students.Add(student);
    await db.SaveChangesAsync();

    return Results.Created($"/api/students/{student.FirstName}", student);
});

app.Run();

public class Students
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int Age { get; set; }
}