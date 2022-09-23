using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMercadoNetoOnLine.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace SuperMercadoNetoOnLine
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
            services.AddRazorPages();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Database")));

            //services.AddDbContext<ApplicationDBContext>(options =>
            //        options.UseSqlite(Configuration.GetConnectionString("ApplicationDBContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles(); // habilitar a leitura da pasta wwwroot

            app.UseRouting();    // mecanismo de roteamento de paginas URL 

            app.UseAuthorization();    // habilitar auth baseada usuario e senha, cookies de authoriza��o
            
            app.UseEndpoints(endpoints =>       
            {
                endpoints.MapRazorPages();
            });
            


            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };
            app.UseRequestLocalization(localizationOptions);
        }
    }
}
