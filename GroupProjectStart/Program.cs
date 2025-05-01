using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Caching.Memory;
using GroupProjectStart.Data;
using GroupProjectStart.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("SkillSwapDB"));

builder.Services.AddMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "SkillSwap API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//Our Endpoints
app.MapGet("/api/v1/skilloffers", async (AppDbContext db, [FromQuery] int page = 1, [FromQuery] int pageSize = 5) =>
{
    if (page * pageSize > await db.SkillOffers.CountAsync())
        return Results.BadRequest("No more offers to show");

    var total = await db.SkillOffers.CountAsync();
    var offers = await db.SkillOffers
        .OrderBy(offer => offer.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();


    return Results.Ok(new { total, page, pageSize, offers });
});

app.MapGet("/api/v1/skilloffers/{id}", async (AppDbContext db, int id, IMemoryCache cache) =>
{
    if (!cache.TryGetValue($"SkillOffer_{id}", out SkillOffer offer))
    {
        offer = await db.SkillOffers.FindAsync(id);
        if (offer == null) return Results.NotFound();

        cache.Set($"SkillOffer_{id}", offer, TimeSpan.FromMinutes(5));
    }

    return Results.Ok(offer);
});

app.MapPost("/api/v1/skilloffers", async (AppDbContext db, SkillOffer offer) =>
{
    db.SkillOffers.Add(offer);
    await db.SaveChangesAsync();
    return Results.Created($"/api/v1/skilloffers/{offer.Id}", offer);
});

app.MapPut("/api/v1/skilloffers/{id}", async (AppDbContext db, int id, SkillOffer updatedOffer) =>
{
    var offer = await db.SkillOffers.FindAsync(id);
    if (offer == null) return Results.NotFound();

    offer.Title = updatedOffer.Title;
    offer.Description = updatedOffer.Description;
    offer.Category = updatedOffer.Category;
    offer.Location = updatedOffer.Location;

    await db.SaveChangesAsync();
    return Results.Ok(offer);
});

app.MapDelete("/api/v1/skilloffers/{id}", async (AppDbContext db, int id) =>
{
    var offer = await db.SkillOffers.FindAsync(id);
    if (offer == null) return Results.NotFound();

    db.SkillOffers.Remove(offer);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();


