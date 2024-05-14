using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using UploadFileApiProject.Application.Contracts;
using UploadFileApiProject.Application.Services;
using UploadFileApiProject.Infrastructure;
using UploadFileApiProject.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddDbContext<IApplicationContext,SqlServerApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UploadFileConnection"));
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPictureService, PictureService>();

var app = builder.Build();



DefaultFilesOptions options = new();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("Homepage.html");

app.UseDefaultFiles(options);

app.UseStaticFiles();

// Specific Static File Path

/*
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
    RequestPath = "/incodityImage"
});
*/



app.MapControllers();

app.Run();
