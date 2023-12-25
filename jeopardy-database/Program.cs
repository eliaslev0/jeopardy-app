global using jeopardy.EntityModels;
global using Microsoft.EntityFrameworkCore;
global using System.Text.Json.Serialization;
using jeopardy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer((options) => {
    options.TokenValidationParameters = new TokenValidationParameters(){
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<jeopardyContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<JeopardyService>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddControllers().AddOData(opt => {
                opt.AddRouteComponents("odata", GetEdmModel());
                opt.Filter().Select().Expand().OrderBy().SetMaxTop(null).Count();
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
 
    builder.EntitySet<Clue>("Clues");
 
    return builder.GetEdmModel();
}