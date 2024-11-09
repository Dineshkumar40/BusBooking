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
         string JwtRsaPublicKey = "MIIBCgKCAQEA5nSzCdDYzVQULW9uRmLB5yNqgBk4xqfo4tMKE/a2Cbb2O1DWOfsHeWyoZLS+9LtwC85ZT7hRgJehgFZbhW6BK4w5SVu+PnEbxbZI0tNfT/WfxV9DanS2NoImJadc5H6fOloYtxQLKYaI+AiXDQXeC9Kg3JYBc/J1Z4YIouARi+psWmWkbsbFKF+v/K0Kb6ikDUtIVc8+JF44CRIdEZwNgKkZUrbp/tsF6sU+QivxaLVp+9cZYAb14evg7qT2eZpNOHr2tvxxqA/W1pudn+3xcrJND4NiFwVYATN7im9RX7pCIooGplUOIWGiA5OfoQX5OKamRVTF0bU+puxZr9b+YQIDAQAB";
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
