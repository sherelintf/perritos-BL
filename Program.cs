using BL.Repositories.Interfaces;
using BL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressMapClientErrors = true;
    });
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "BL API";
    options.Description = "BL API";
    options.DocumentName = "v1";
    options.Version = "v1";
});
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

builder.Services.AddCors();
builder.Services.AddScoped<IDogRepository, DogRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi(c =>
    {
        c.DocumentTitle = "BL API";
    });
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
