using Huub.API.Interfaces;
using Huub.API.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<IHttpService, HttpService>();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Joel Martins Huub Case Study",
            Description = "An ASP.NET Core Web API for Huub By Maersk's first challenge.",
            Contact = new OpenApiContact
            {
                Name = "Joel Martins",
                Url = new Uri("https://www.linkedin.com/in/joelm-artins"),
                Email = "joelflm@gmail.com"
            }
        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Huub Case Study");
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
