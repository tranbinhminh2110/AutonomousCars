using BotTournamentManagement.Data;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Repository;
using BotTournamentManagement.Service;
using BotTournamentManagement.Extensions;
using Microsoft.IdentityModel.Tokens;
using static BotTournamentManagement.Extensions.ApiKeyAuthorizationFilter;
using System.Text;
using BotTournamentManagement.Services;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using BotTournamentManagement.Swagger;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins( "http://localhost:3000", "https://magenta-meerkat-812299.netlify.app", "https://dat--gentle-dusk-aeb080.netlify.app",
                                              "https://websiteadminfptbot.netlify.app")
                                               .AllowAnyHeader()
                                               .AllowAnyMethod(); 
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMapRepository, MapRepository>();
builder.Services.AddScoped<IMapService, MapService>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IHighSchoolRepository, HighSchoolRepository>();
builder.Services.AddScoped<IHighSchoolService, HighSchoolService>();
builder.Services.AddScoped<IRoundRepository, RoundRepository>();
builder.Services.AddScoped<IRoundService, RoundService>();
builder.Services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
builder.Services.AddScoped<IActivityTypeService, ActivityTypeService>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<ITeamInMatchRepository, TeamInMatchRepository>();
builder.Services.AddScoped<ITeamInMatchService, TeamInMatchService>();
builder.Services.AddScoped<ITeamActivityRepository, TeamActivityRepository>();
builder.Services.AddScoped<ITeamActivityService, TeamActivityService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();
builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(o =>
{
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("suifbweudfwqudgweufgewufgwefcgweiudgweidgwed"))
    };
});
builder.Services.AddAuthorization(o => {
    o.AddPolicy("Organizer", policy => policy.RequireClaim(ClaimTypes.Role, "Organizer"));
    o.AddPolicy("Head Referee", policy => policy.RequireClaim(ClaimTypes.Role, "Head Referee"));
    o.AddPolicy("Referee", policy => policy.RequireClaim(ClaimTypes.Role, "Referee"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
