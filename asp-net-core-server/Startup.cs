using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;

namespace AspNetCoreDashboardBackend {
    public class Startup {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment) {
            Configuration = configuration;
            FileProvider = hostingEnvironment.ContentRootFileProvider;
        }

        public IConfiguration Configuration { get; }
        public IFileProvider FileProvider { get; }

        public void ConfigureServices(IServiceCollection services) {
            services
                // Configures CORS policies.                
                .AddCors(options => {
                    options.AddPolicy("CorsPolicy", builder => {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.WithHeaders("Content-Type");
                    });
                })
                // Adds the DevExpress middleware.
                .AddDevExpressControls()
                // Adds controllers.
                .AddControllers()
                // Configures the dashboard backend.
                .AddDefaultDashboardController(configurator => {
                    configurator.SetDashboardStorage(new DashboardFileStorage(FileProvider.GetFileInfo("App_Data/Dashboards").PhysicalPath));
                    configurator.SetDataSourceStorage(CreateDataSourceStorage());
                    configurator.ConfigureDataConnection += Configurator_ConfigureDataConnection;
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            // Registers the DevExpress middleware.            
            app.UseDevExpressControls();
            // Registers routing.
            app.UseRouting();
            // Registers CORS policies.
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints => {
                // Maps the dashboard route.
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "api/dashboard");
                // Requires CORS policies.
                endpoints.MapControllers().RequireCors("CorsPolicy");
            });
        }
        public DataSourceInMemoryStorage CreateDataSourceStorage() {
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            DashboardJsonDataSource jsonDataSource = new DashboardJsonDataSource("Customers");
            jsonDataSource.RootElement = "Customers";
            dataSourceStorage.RegisterDataSource("jsonDataSourceSupport", jsonDataSource.SaveToXml());
            return dataSourceStorage;
        }
        private void Configurator_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.DataSourceName.Contains("Customers")) {
                Uri fileUri = new Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json");
                JsonSourceConnectionParameters jsonParams = new JsonSourceConnectionParameters();
                jsonParams.JsonSource = new UriJsonSource(fileUri);
                e.ConnectionParameters = jsonParams;
            }
        }
    }
}