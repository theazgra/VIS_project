using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            DistilleryLogic.Configuration.SetDbConnection(
                DataLayerNetCore.DBType.XmlDatabase,
                @"C:\Users\Vojtěch\Source\Repos\VIS_projekt\Aplikace\DistilleryDbLib\WebApp\DistXml.xml");

            //DistilleryLogic.Configuration.SetDbConnection(
            //    DataLayerNetCore.DBType.SqlServer,
            //    @"data source = dbsys.cs.vsb.cz\STUDENT; initial catalog = mor0146; user id = mor0146; password = Wt0pEzMOWp");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddSessionStateTempDataProvider();

            services.AddSession();

            services.AddSingleton<UserSession>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
