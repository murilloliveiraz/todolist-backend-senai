using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using todolist_backend_senai.Contexts;
using todolist_backend_senai.Helpers;
using todolist_backend_senai.Profiles;
using todolist_backend_senai.Repositories;

var builder = WebApplication.CreateBuilder(args);

ConfigurarInjecaoDeDependencia(builder);

ConfigurarServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

ConfigurarAplicacao(app);

app.Run();


// Metodo que configrua as inje??es de dependencia do projeto.
static void ConfigurarInjecaoDeDependencia(WebApplicationBuilder builder)
{
    string? connectionString = builder.Configuration.GetConnectionString("Postgres");
    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseNpgsql(connectionString), ServiceLifetime.Transient, ServiceLifetime.Transient
    );

    var config = new MapperConfiguration(configs => {
        configs.AddProfile<UserProfile>();
        configs.AddProfile<TaskProfile>();
    });


    IMapper mapper = config.CreateMapper();

    builder.Services
    .AddSingleton(builder.Configuration)
    .AddSingleton(builder.Environment)
    .AddSingleton(mapper)
    .AddHttpClient()
    .AddScoped<ITaskRepository, TaskRepository>()
    .AddScoped<IUserRepository, UserRepository>();
}

// Configura o servi?os da API.
static void ConfigurarServices(WebApplicationBuilder builder)
{
    builder.Services
    .AddCors()
    .AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JTW Authorization header using the Beaerer scheme (Example: 'Bearer 12345abcdef')",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer"
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
                Array.Empty<string>()
            }
        });
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoList.Api", Version = "v1" });
    });

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
}

// Configura os servi?os na aplica??o.
static void ConfigurarAplicacao(WebApplication app)
{
    // Configura o contexto do postgreSql para usar timestamp sem time zone.
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    app.UseDeveloperExceptionPage()
        .UseRouting();

    app.UseSwagger()
        .UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList.Api v1");
            c.RoutePrefix = string.Empty;
        });

    var devClient = "http://localhost:4200";
    app.UseCors(x => x
        .AllowAnyOrigin() // Permite todas as origens
        .AllowAnyMethod() // Permite todos os m?todos
        .AllowAnyHeader()) // Permite todos os cabe?alhos
        .UseAuthentication();

    app.UseAuthorization();

    app.UseEndpoints(endpoints => endpoints.MapControllers());

    app.MapControllers();
}
