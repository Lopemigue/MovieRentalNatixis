using MovieRental.Data;
using MovieRental.ExceptionHandler;
using MovieRental.Models.Customer;
using MovieRental.Models.Movie;
using MovieRental.Models.Rental;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<MovieRentalDbContext>();

builder.Services.AddScoped<IRentalFeatures, RentalFeatures>();
builder.Services.AddScoped<IMovieFeatures, MovieFeatures>();
builder.Services.AddScoped<ICustomerFeatures, CustomerFeatures>();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MovieRentalDbContext>();
    db.Database.EnsureCreated();

}

app.Run();
