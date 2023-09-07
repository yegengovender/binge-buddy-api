using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json") // Load configuration from appsettings.json
    .Build();

// Configure SQLite
var connectionString = builder.Configuration.GetConnectionString("SQLiteConnection");
builder.Services.AddDbContext<UserDb>(opt => opt.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<UserDb>();

    dbContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

// USER
app.MapGet("/users", async (UserDb db) =>
{
    var users = await db.Users.ToListAsync();
    return Results.Ok(users);
});

app.MapPost("/users", async (UserDb db, [FromBody] User user) =>
{
    await db.Users.AddAsync(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

// SHOW
app.MapGet("/shows", async (UserDb db) =>
{
    var shows = await db.Shows.ToListAsync();
    return Results.Ok(shows);
});

app.MapPost("/shows", async (UserDb db, [FromBody] Show show) =>
{
    await db.Shows.AddAsync(show);
    await db.SaveChangesAsync();
    return Results.Created($"/shows/{show.Id}", show);
});

// EPISODE
app.MapGet("/episodes", async (UserDb db) =>
{
    var episodes = await db.TvEpisodes.ToListAsync();
    return Results.Ok(episodes);
});

app.MapPost("/episodes", async (UserDb db, [FromBody] TvEpisode episode) =>
{
    await db.TvEpisodes.AddAsync(episode);
    await db.SaveChangesAsync();
    return Results.Created($"/episodes/{episode.Id}", episode);
});

// app.MapGet("/users/{id}", async (UserDb db, int id) =>
// {
//     var user = await db.Users.FindAsync(id);
//     if (user is null)
//     {
//         return Results.NotFound();
//     }
//     return Results.Ok(user);
// });


// app.MapGet("/users/{id}/shows", async (UserDb db, int id) =>
// {
//     var user = await db.Users.FindAsync(id);
//     if (user is null)
//     {
//         return Results.NotFound();
//     }
//     return Results.Ok(user.Shows?.ToList());
// });

// app.MapPost("/users/{id}/shows", async (UserDb db, int id, Show show) =>
// {
//     var user = await db.Users.FindAsync(id);
//     if (user is null)
//     {
//         return Results.NotFound();
//     }

// //    await db.Shows.AddAsync(show);

//     user.Shows ??= new List<Show>();

//     user.Shows.Add(show);
//     await db.SaveChangesAsync();
//     return Results.Ok(user.Shows?.ToList());
// });

app.MapGet("/", () => "Hello World!");

app.Run();
