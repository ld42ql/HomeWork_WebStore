using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Models;
using WebStore.Dal.Context;
using WebStore.Domain.Entities;
using WebStore.Interfaces;
using WebStore.Implementation.InMemory;
using WebStore.Implementation.SQL;
using WebStore.Implementation.Cart;
using WebStore.Interfaces.Api;
using WebStore.Clients.Values;

namespace WebStore
{
    public class Startup
    {
        /// <summary>
        /// Добавляем свойство для доступа к файлу конфигурации
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Конструктор принимающий файл конфигурации
        /// </summary>
        /// <param name="configuration">файл конфигурации</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Добавляем сервисы, необходимые для mvc
            services.AddMvc();

            #region Добавляем разрешение зависимости

            services.AddSingleton<IWorkingData<EmployeeView>, EmployeeList>();
            //services.AddSingleton<IProductData, ProductData>();
            services.AddScoped<IProductData, ProductDataSql>();

            services.AddTransient<ICartStore, CookiesCartStore>();
            services.AddTransient<ICartService, CartService>();

            #endregion

            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            #region testApiClient

            services.AddTransient<IValuesService, ValuesClient>();

            #endregion

            #region Identity

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                #region Правила пароля
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                #endregion

                #region Правила Lockout
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                #endregion

                #region Правила для пользователя
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
                #endregion
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);

                options.LoginPath = "/Account/LoginOrRegister";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";

                options.SlidingExpiration = true;
            });
            
                #endregion
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            //Добавляем расширение для использования статических файлов и добавляем обработку запросов в mvc-формате
            app.UseStaticFiles();
            
            app.UseWelcomePage("/welcome");

            app.UseAuthentication();

            //добавляем обработку запросов в mvc-формате
            app.UseMvc(routes =>
            {

                routes.MapRoute("tableUsers", "users/table", 
                    new { controller = "Employee", action = "Index"}
                    );
                routes.MapRoute("employee", "users/{action}",
                    new { controller = "Employee" }
                    );
                routes.MapRoute("shop", "shop",
                    new { controller = "Home", action = "Shop"}
                    );
                routes.MapRoute("Account", "account",
                    new { controller = "Account", action = "LoginOrRegister" }
                    );
                routes.MapRoute(
                                name: "default",
                                template: "{controller=Home}/{action=Index}/{id?}");
            }
                     );

        }
    }
}