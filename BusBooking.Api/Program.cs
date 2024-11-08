using BusBooking.Repositories;
using BusBooking.Repositories.Interfaces;
using BusBooking.Services;
using BusBooking.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
     {
         string JwtRsaPublicKey = "MIIBCgKCAQEA8m5lWBlWxwJMCt168RBPnwAe8oy702fANVwFSKOnGEMI+os5kbeQX8ulUY82euj4d2P2ngmeu5PK2NF7J5YWdXoDjXrbegQn3F0SV7K66HBFuyNDQwGIi8B2PWR3qIAVVZBuy0VrMSW5wxJpIt7WBW1CUleO/QgZ9vXbCRqz8U6407lORYuV1ca/BPjFd/iKTnO6mTtGonBBljEeKcBcSQyTWaJJny8xySapkxQt6UWdCHLeBZ+H2HyC+pUGbGLJaLz0/zdu+3z40puK5SfQtU1KVOehEzb82lTfISTBFmHQzx50nk0Fnt6n3kOqoHRqz9k0QfKfXCe4Pv8RttSIxQIDAQAB";
         RSA rSA = RSA.Create();
         var publicKeyBytes = Convert.FromBase64String(JwtRsaPublicKey);
         rSA.ImportRSAPublicKey(publicKeyBytes, out int _);
         RsaSecurityKey SecurityKey = new RsaSecurityKey(rSA);

         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = false,
             //ValidIssuer = "hexaware",
             IssuerSigningKey = SecurityKey,
             ValidateLifetime = true,
             ValidateAudience = false,
             RequireSignedTokens = true,
             RequireExpirationTime = true,
         };
     });

//builder.Services.AddSingleton<IDapperSqlProvider>(provider => new DapperSqlProvider(builder.Configuration.GetValue<string>("App_Settings:ConnectionString", string.Empty)));
builder.Services.AddSingleton<IDapperSqlProvider>(provider => new DapperSqlProvider(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=BusBooking;Integrated Security=True"));


builder.Services.AddSingleton<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<IUsersService, UsersService>();
builder.Services.AddSingleton<ILogInServices, LogInServices>();

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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
