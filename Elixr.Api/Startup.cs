using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Services;
using Elixr2.Api.Services.Seeding;
using Elixr2.Api.Filters;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;

namespace Elixr2
{
    public class Startup
    {
        private readonly IConfigurationRoot configuration;
        public Startup(IHostingEnvironment environment)
        {
            configuration = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory())
                                                      .AddJsonFile(System.IO.Path.Combine("Settings", $"AppSettings.{environment.EnvironmentName}.json"))
                                                      .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opts => 
            {
                 opts.Filters.Add(typeof(AuthenticationFilter));
                 opts.Filters.Add(typeof(GlobalExceptionFilter));
            });
            services.Configure<FormOptions>(fo =>
            {
                fo.MultipartBodyLengthLimit = int.MaxValue;
                fo.ValueLengthLimit = int.MaxValue;
                fo.MemoryBufferThreshold = int.MaxValue;
                fo.MultipartBodyLengthLimit = int.MaxValue; //Let the service decide how large of a file it wants to accept.
            });

            //todo : retrieve settings from config file
            services.AddDbContext<ElixrDbContext>(opt => opt.UseInMemoryDatabase("InMemory"));// .UseNpgsql("Server=127.0.0.1;Port=5432;Database=Elixr2;User Id=elixr_user;Password=elixr_password;"));
            services.AddScoped<CampaignSettingsService>();
            services.AddScoped<CreaturesService>();
            services.AddScoped<CharacteristicsService>();
            services.AddScoped<WeaponsService>();
            services.AddScoped<ItemsService>();
            services.AddScoped<ArmorService>();
            services.AddScoped<SpellsService>();
            services.AddScoped<TemplatesService>();
            services.AddScoped<GamerService>();
            services.AddScoped<ObjectStorageService>();
            services.AddScoped<StatsService>();
            services.AddScoped<UserSession>();
            services.AddTransient<SeedService>();

            services.AddSingleton(s => new SettingsService(configuration["S3AccessKeyID"], configuration["S3SecretKey"], configuration["SecretHashingKey"], configuration["TheGameMasterPassword"]));
            services.AddSingleton<UtilityService>();
            services.AddSingleton<TokenSigner>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ElixrDbContext dbContext,
        SeedService seedService, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowAll");
            }

            app.UseMvc();

            try
            {
                seedService.SeedInitial(false).Wait();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                dbContext.Database.EnsureDeleted();
                ;
            }
        }
    }
}
