using BareNakedBlazor;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();
builder.Services.AddRazorComponents();

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/hello"));
app.MapGet("/hello", () => new RazorComponentResult<Hello>());
app.MapPost("/hello", ([FromForm] string firstName) =>
   new RazorComponentResult<Hello>(new { FirstName = firstName })
).DisableAntiforgery();

app.Run();
