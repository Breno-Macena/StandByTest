using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StandByTest.Database;
using StandByTest.Models;
using StandByTest.Models.Validators;
using System.Globalization;

namespace StandByTest {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-Br");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews().AddFluentValidation();
            services.AddDbContext<StandByDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("StandByDbConnection"));
            });

            services.AddTransient<IValidator<Cliente>, ClienteValidator>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Clientes}/{action=Index}/{id?}");
            });
        }
    }
}
