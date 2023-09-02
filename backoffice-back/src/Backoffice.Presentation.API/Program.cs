using Backoffice.Application.Services.Authentication;
using Backoffice.Application.Services.Departamentos;
using Backoffice.Application.Services.Pessoas;
using Backoffice.Application.Services.Pessoas.Mapper;
using Backoffice.Domain.Repository;
using Backoffice.Infra.Data.Repository;
using Backoffice.Presentation.API.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition =
        System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backoffice", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.AddIdentityConfiguration();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoasService, PessoasService>();

builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

builder.Services.AddAutoMapper(typeof(PessoaProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

using (var serviceProvider = builder.Services.BuildServiceProvider())
{
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    AdminUserInitializer.InitializeAsync(userManager, roleManager).Wait();
}

app.MapControllers();

app.Run();