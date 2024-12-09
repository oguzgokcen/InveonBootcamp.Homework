using InveonBootcamp.Homework.LibraryApi.ExceptionHandler;
using InveonBootcamp.Homework.LibraryApi.Exceptions.ExceptionsHandlers;
using InveonBootcamp.Homework.LibraryApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILibraryRetrieveRepository,LibraryRetrieveRepository>();
builder.Services.AddScoped<ILibraryCrudRepository, LibraryCrudRepository>();
builder.Services.AddScoped<ICacheRepository, CacheRepository>();
builder.Services.AddLogging(builder => builder.AddConsole());
builder.Services.AddCustomExceptionHandler();

builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
	redisOptions.Configuration = builder.Configuration.GetConnectionString("Redis");
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();

app.MapControllers();

app.Run();
