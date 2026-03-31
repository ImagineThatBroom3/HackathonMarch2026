using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

// Serve static files from the "website" subdirectory.
var root = Directory.GetCurrentDirectory();
var webRoot = Path.Combine(root, "website");
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = root,
    WebRootPath = webRoot
});

var app = builder.Build();

var rootProvider = new PhysicalFileProvider(webRoot);
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
