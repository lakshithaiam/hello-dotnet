using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory visitor counter
int visitorCount = 0;

app.MapGet("/", async (HttpContext context) =>
{
    visitorCount++;

    // Server info
    var hostname = Dns.GetHostName();
    var clientIP = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
    var os = RuntimeInformation.OSDescription;
    var dotnetVersion = RuntimeInformation.FrameworkDescription;

    await context.Response.WriteAsync("<h1>Hello from .NET </h1>");
    await context.Response.WriteAsync($"<p>Server Hostname: {hostname}</p>");
    await context.Response.WriteAsync($"<p>Client IP: {clientIP}</p>");
    await context.Response.WriteAsync($"<p>Visitor number: {visitorCount}</p>");
    await context.Response.WriteAsync($"<p>OS: {os}</p>");
    await context.Response.WriteAsync($"<p>.NET Version: {dotnetVersion}</p>");
});

app.Run();
