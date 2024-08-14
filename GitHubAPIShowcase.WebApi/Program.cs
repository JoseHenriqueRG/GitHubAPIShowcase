using GitHubAPIShowcase.Application;
using GitHubAPIShowcase.Domain.Interfaces;
using GitHubAPIShowcase.Infra.ApiGitHub;
using GitHubAPIShowcase.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGitHubApi, GitHubApi>();
builder.Services.AddScoped<IGitHubApiApplication, GitHubApplication>();
builder.Services.AddScoped<IGitHubFavoriteApplication, GitHubFavoriteApplication>();
builder.Services.AddScoped<IContextRepository, ContextRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
