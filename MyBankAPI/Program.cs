using MyBankAPI.Data;
using MyBankAPI.Models;
using MyBankAPI.Services.LoanApplicationService;
using AutoMapper.Configuration;
using MyBankAPI.Models.Domain;
using MyBankAPI.Repository.LoanApplicationRepository;
using MyBankAPI.Repositories;
using MyBankAPI.Services.CuurencyService;
using MyBankAPI.Repositories.CuurencyRepository;
using MyBankAPI.Repositories.LoanStatusRepository;
using MyBankAPI.Services.LoanStatusService;
using MyBankAPI.Repositories.LoanTypeRerpsitory;
using MyBankAPI.Services.LoanTypeService;
using MyBankAPI.MiddleWares;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
configuration.WriteTo.File("Log/Log.txt").MinimumLevel.Information());

var tkConf = builder.Configuration.GetSection("Jwt");
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = tkConf["Issuer"],
    ValidAudience = tkConf["Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tkConf["key"]))

};

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = tokenValidationParameters;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    o =>
    {
        o.SignIn.RequireConfirmedAccount = false;
        o.Password.RequireDigit = false;
        o.Password.RequireNonAlphanumeric = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireLowercase = false;
    }).AddEntityFrameworkStores<DataContext>();

//register dependency
builder.Services.AddScoped<IBaseRepository<LoanApplication>, LoanApplicationRepository>();
builder.Services.AddScoped<ILoanApplicationService, LoanApplicationService>();
builder.Services.AddScoped<ILoanApplicationRepository, LoanApplicationRepository>();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<IBaseRepository<Currency>, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IBaseRepository<LoanStatus>, LoanStatusRepository>();
builder.Services.AddScoped<ILoanStatusRepository, LoanStatusRepository>();
builder.Services.AddScoped<ILoanStatusService, LoanStatusService>();

builder.Services.AddScoped<IBaseRepository<LoanType>, LoanTypeRepository>();
builder.Services.AddScoped<ILoanTypeRepository, LoanTypeRepository>();
builder.Services.AddScoped<ILoanTypeService, LoanTypeService>();


builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();



using (var dbContext = new DataContext(builder.Configuration))
{
    dbContext.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
