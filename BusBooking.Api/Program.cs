using BusBooking.Repositories;
using BusBooking.Repositories.Interfaces;
using BusBooking.Services;
using BusBooking.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IDapperSqlProvider>(provider => new DapperSqlProvider(builder.Configuration.GetValue<string>("App_Settings:ConnectionString", string.Empty)));
builder.Services.AddSingleton<IDapperSqlProvider>(provider => new DapperSqlProvider(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=BusBooking;Integrated Security=True"));


builder.Services.AddSingleton<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<IUsersService, UsersService>();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
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

// Enable CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
