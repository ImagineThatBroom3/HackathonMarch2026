using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

// Ensure web root is set to project folder so we don't rely on wwwroot.
var root = Directory.GetCurrentDirectory();
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = root,
    WebRootPath = root
});

var app = builder.Build();

var rootProvider = new PhysicalFileProvider(root);
app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = rootProvider,
    DefaultFileNames = new[] { "index.html" }
});
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = rootProvider,
    RequestPath = ""
});

app.MapFallbackToFile("index.html");

app.Run();
