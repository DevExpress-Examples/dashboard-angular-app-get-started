Imports DevExpress.AspNetCore
Imports DevExpress.DashboardAspNetCore
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.Json
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.FileProviders
Imports System

Namespace AspNetCoreDashboardBackend
	Public Class Startup
		' This method gets called by the runtime. Use this method to add services to the container.
		' For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

		Public Sub New(ByVal configuration As IConfiguration, ByVal hostingEnvironment As IWebHostEnvironment)
			Me.Configuration = configuration
			FileProvider = hostingEnvironment.ContentRootFileProvider
		End Sub

		Public ReadOnly Property Configuration() As IConfiguration
		Public ReadOnly Property FileProvider() As IFileProvider

		' This method gets called by the runtime. Use this method to add services to the container.
		Public Sub ConfigureServices(ByVal services As IServiceCollection)
			' Configures services to use the Web Dashboard Control.
			services.AddCors(Sub(options)
				options.AddPolicy("CorsPolicy", Sub(builder)
					builder.AllowAnyOrigin()
					builder.AllowAnyMethod()
					builder.WithHeaders("Content-Type")
				End Sub)
			End Sub).AddDevExpressControls().AddControllers().AddDefaultDashboardController(Sub(configurator)
				configurator.SetDashboardStorage(New DashboardFileStorage(FileProvider.GetFileInfo("App_Data/Dashboards").PhysicalPath))
				configurator.SetDataSourceStorage(CreateDataSourceStorage())
				configurator.SetConnectionStringsProvider(New DashboardConnectionStringsProvider(Configuration))
				AddHandler configurator.ConfigureDataConnection, AddressOf Configurator_ConfigureDataConnection
			End Sub)
		End Sub

		' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IWebHostEnvironment)
			' Registers the DevExpress middleware.
			app.UseDevExpressControls()
			app.UseRouting()
			app.UseCors("CorsPolicy")
			app.UseEndpoints(Sub(endpoints)
				EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "api/dashboard")
				endpoints.MapControllers().RequireCors("CorsPolicy")
			End Sub)
		End Sub

		Public Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()

			Dim jsonDataSourceSupport As New DashboardJsonDataSource("Support")
			jsonDataSourceSupport.RootElement = "Employee"
			dataSourceStorage.RegisterDataSource("jsonDataSourceSupport", jsonDataSourceSupport.SaveToXml())

			Dim jsonDataSourceCategories As New DashboardJsonDataSource("Categories")
			jsonDataSourceCategories.RootElement = "Products"
			dataSourceStorage.RegisterDataSource("jsonDataSourceCategories", jsonDataSourceCategories.SaveToXml())
			Return dataSourceStorage
		End Function
		Private Sub Configurator_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
			If e.DataSourceName.Contains("Support") Then
				Dim fileUri As New Uri(FileProvider.GetFileInfo("App_data/Support.json").PhysicalPath, UriKind.RelativeOrAbsolute)
				Dim jsonParams As New JsonSourceConnectionParameters()
				jsonParams.JsonSource = New UriJsonSource(fileUri)
				e.ConnectionParameters = jsonParams
			End If
			If e.DataSourceName.Contains("Categories") Then
				Dim fileUri As New Uri(FileProvider.GetFileInfo("App_data/Categories.json").PhysicalPath, UriKind.RelativeOrAbsolute)
				Dim jsonParams As New JsonSourceConnectionParameters()
				jsonParams.JsonSource = New UriJsonSource(fileUri)
				e.ConnectionParameters = jsonParams
			End If
		End Sub
	End Class
End Namespace