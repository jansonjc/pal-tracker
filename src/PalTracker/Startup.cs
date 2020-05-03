using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PalTracker
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      services.AddSingleton(sp => new WelcomeMessage(
        Configuration.GetValue<string>("WELCOME_MESSAGE", "WELCOME_MESSAGE not configured.")
        ));

      services.AddSingleton(sp => new CloudFoundryInfo(
        Configuration.GetValue<string>("PORT", "Not set"),
        Configuration.GetValue<string>("MEMORY_LIMIT", "Not set"),
        Configuration.GetValue<string>("CF_INSTANCE_INDEX", "Not set"),
        Configuration.GetValue<string>("CF_INSTANCE_ADDR", "Not set")
        ));

      services.AddSingleton<ITimeEntryRepository, InMemoryTimeEntryRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
