using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb.Native;
using DevExpress.DashboardWeb;
using Microsoft.Extensions.FileProviders;
using DevExpress.AspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.Json;

var builder = WebApplication.CreateBuilder(args);

IFileProvider? fileProvider = builder.Environment.ContentRootFileProvider;
IConfiguration? configuration = builder.Configuration;

// Configures CORS policies.                
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.WithHeaders("Content-Type");
    });
});

// Adds the DevExpress middleware.
builder.Services.AddDevExpressControls();
// Adds controllers.
builder.Services.AddControllersWithViews();

// Configures the dashboard backend.
builder.Services.AddScoped<DashboardConfigurator>((IServiceProvider serviceProvider) => {
    DashboardConfigurator configurator = new DashboardConfigurator();
    configurator.SetDashboardStorage(new DashboardFileStorage(fileProvider.GetFileInfo("Data/Dashboards").PhysicalPath));
    configurator.SetDataSourceStorage(CreateDataSourceStorage());
    configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration));
    configurator.ConfigureDataConnection += Configurator_ConfigureDataConnection;
    return configurator;
});

void Configurator_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
    if (e.ConnectionName == "jsonSupport") {
        Uri fileUri = new Uri(fileProvider.GetFileInfo("Data/support.json").PhysicalPath, UriKind.RelativeOrAbsolute);
        JsonSourceConnectionParameters jsonParams = new JsonSourceConnectionParameters();
        jsonParams.JsonSource = new UriJsonSource(fileUri);
        e.ConnectionParameters = jsonParams;
    }
    if (e.ConnectionName == "jsonCategories") {
        Uri fileUri = new Uri(fileProvider.GetFileInfo("Data/categories.json").PhysicalPath, UriKind.RelativeOrAbsolute);
        JsonSourceConnectionParameters jsonParams = new JsonSourceConnectionParameters();
        jsonParams.JsonSource = new UriJsonSource(fileUri);
        e.ConnectionParameters = jsonParams;
    }
}

DataSourceInMemoryStorage CreateDataSourceStorage() {
    DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

    DashboardJsonDataSource jsonDataSourceSupport = new DashboardJsonDataSource("Support");
    jsonDataSourceSupport.ConnectionName = "jsonSupport";
    jsonDataSourceSupport.RootElement = "Employee";
    dataSourceStorage.RegisterDataSource("jsonDataSourceSupport", jsonDataSourceSupport.SaveToXml());

    DashboardJsonDataSource jsonDataSourceCategories = new DashboardJsonDataSource("Categories");
    jsonDataSourceCategories.ConnectionName = "jsonCategories";
    jsonDataSourceCategories.RootElement = "Products";
    dataSourceStorage.RegisterDataSource("jsonDataSourceCategories", jsonDataSourceCategories.SaveToXml());
    return dataSourceStorage;
}

var app = builder.Build();

// Registers the DevExpress middleware.            
app.UseDevExpressControls();

// Registers routing.
app.UseRouting();
// Registers CORS policies.
app.UseCors("CorsPolicy");

// Maps the dashboard route.
app.MapDashboardRoute("api/dashboard", "DefaultDashboard");
// Requires CORS policies.
app.MapControllers().RequireCors("CorsPolicy");

app.Run();