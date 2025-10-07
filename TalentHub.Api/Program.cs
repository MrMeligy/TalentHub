using AutoMapper; // Ensure AutoMapper namespace is included
using TalentHub.Extensions;
using Microsoft.EntityFrameworkCore;
using TalentHub.Api.Mapping;
using TalentHub.Business.Abstraction;
using TalentHub.Business.Contracts;
using TalentHub.Business.Services;
using TalentHub.Data;
using TalentHub.Data.Repositories;
using TalentHub.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(conn));
// Add services to the container.
// DI
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerSkillRepository, PlayerSkillRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IPlayerMatchRepository, PlayerMatchRepository>();

builder.Services.AddScoped<IAcademyService, AcademyService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAcademyTeamService, AcademyTeamService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerSkillService, PlayerSkillService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IPlayerMatchService, PlayerMatchService>();

// Fix: Use the correct overload for AddAutoMapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", p => p
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});
builder.Services.AddSwaggerGenJwtAuth();
builder.Services.AddCustomJwtAuthExtension(builder.Configuration); //My Extension


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
