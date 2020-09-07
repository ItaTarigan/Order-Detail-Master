using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BalitTanahPelayanan.Data;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using Silpo.Tools;
using BalitTanahPelayanan.Helpers;
using System.Globalization;

namespace BalitTanahPelayanan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
            services.AddBlazoredToast();
            services.AddTransient<BlazorTimer>();
            System.Data.Common.DbProviderFactories.RegisterFactory("System.Data.SqlClient", "System.Data.SqlClient.SqlClientFactory, System.Data.SqlClient");
            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            AppConstants.GMapApiKey = Configuration["GmapKey"];
            AppConstants.DbConnection = Configuration.GetConnectionString("LocalConnection");
           
            AppConstants.UploadFolderPath = Configuration["UploadFolderPath"];
            AppConstants.BlobStorageConnection = Configuration["BlobStorageConnection"];
            AppConstants.DefaultBlobCountainer = Configuration["DefaultBlobCountainer"];
            AppConstants.CryptoKey = Configuration["CryptoKey"];

            

            MailService.MailUser = Configuration["MailSettings:MailUser"];
            MailService.MailPassword = Configuration["MailSettings:MailPassword"];
            MailService.MailServer = Configuration["MailSettings:MailServer"];
            MailService.MailPort = int.Parse(Configuration["MailSettings:MailPort"]);
            SmsService.UserKey = Configuration["SmsSettings:ZenzivaUserKey"];
            SmsService.PassKey = Configuration["SmsSettings:ZenzivaPassKey"];

            services.AddControllers();
            services.AddCors();
            services.AddMvcCore().AddAuthorization().AddApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SILPO Data API",
                    Version = "v1",
                    Description = "Rest API for accessing data",
                    TermsOfService = new Uri("http://silpo.pertanian.go.id"),
                    Contact = new OpenApiContact { Name = "SILPO Dev Team", Email = "silpo@pertanian.go.id", Url = new Uri("http://twitter.com/silpo") },
                    License = new OpenApiLicense { Name = "For developers only", Url = new Uri("http://silpo.pertanian.go.id") }
                });

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            // BLAZOR COOKIE Auth Code (begin)
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();
            services.AddHttpClient();
            services.AddScoped<HttpClient>();
            //multi language
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            var supportedCultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("id") };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                options.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var webRoot = env.WebRootPath;
            AppConstants.WebRootPath = webRoot;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SILPO API V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            app.UseRequestLocalization();
        }
    }
}
