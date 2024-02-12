using ClassLibrary.Models;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//------------------------ Skills ------------------------

//Read, All 
app.MapGet("/skills", async (ApplicationDbContext dbContext) =>
{
    try
    {
        var skills = await dbContext.Skills.ToListAsync();
        return Results.Ok(skills);
    }
    catch
    {
        return Results.Problem("Server Error");
    }
});

//Read, By ID
app.MapGet("/skills/{id}", async (ApplicationDbContext dbContext, Guid id) =>
{
    try
    {
        var product = await dbContext.Skills.FirstOrDefaultAsync(x => x.Id == id);
        if (product != null)
        {
            return Results.Ok(product);
        }
        else
        {
            return Results.NotFound("No product with this ID was found");
        }

    }
    catch
    {
        return Results.Problem("Server Error");
    }
});

//Create
app.MapPost("/skills", async (ApplicationDbContext dbContext, Skills skill) =>
{
    try
    {
        var newSkill = new Skills()
        {
            Title = skill.Title,
            Description = skill.Description,
            SkillLevel = skill.SkillLevel,
            YearsOfExperience = skill.YearsOfExperience,
        };

        await dbContext.Skills.AddAsync(newSkill);
        await dbContext.SaveChangesAsync();
        return Results.Ok(newSkill);

    }
    catch
    {
        return Results.Problem("Server Error");
    }
});


//Update
app.MapPut("/Skills/{id}", async (ApplicationDbContext dbContext, Guid id, Skills skills) =>
{
    try
    {
        var skillsToUpdate = await dbContext.Skills.FirstOrDefaultAsync(x => x.Id == id);

        if (skillsToUpdate != null)
        {
            skillsToUpdate.Title = skills.Title;
            skillsToUpdate.Description = skills.Description;
            skillsToUpdate.SkillLevel = skills.SkillLevel;
            skillsToUpdate.YearsOfExperience = skills.YearsOfExperience;
            

            await dbContext.SaveChangesAsync();
            return Results.Ok(skillsToUpdate);
        }
        else
        {
            return Results.NotFound("No product with this ID was found");
        }

    }
    catch
    {
        return Results.Problem("Server Error");

    }

});

//Delete
app.MapDelete("/skills/{id}", async (ApplicationDbContext dbContext, Guid id) =>
{
    try
    {
        var skillsToDelete = await dbContext.Skills.FirstOrDefaultAsync(x => x.Id == id);

        if (skillsToDelete == null)
        {
            return Results.NotFound("Product was not found.");
        }

        dbContext.Skills.Remove(skillsToDelete);

        await dbContext.SaveChangesAsync();
        return Results.Ok(skillsToDelete);

    }
    catch
    {
        return Results.Problem("Server Error");
    }

});

app.Run();
