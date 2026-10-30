using System.Linq;
using lib;
using Microsoft.AspNetCore.Http;

public class HomeModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () =>
        {
            var processes = TaskManager.GetProcesses();
            return Results.Text(@$"<ul>
                {string.Join("", processes.Select(it => $"<li>{it.Id} {it.Name} {it.MemorySizeInMb:#.##}]</li>"))}
            <ul>", "text/html");
        });
    }
}
