using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using N5SportsStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace N5SportsStore
{
    /// <summary>
    /// Фримен. AspNetCore. Глава 10. N5SportsStore. Улучшение корзины покупок с помощью служб, функционала оплаты и отправки заказов. Максимально приближенный к реальности проект NetCore MVC на NCore 2.1
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
      
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// Метод настройки распределенных обьектов через внедрение зависимостей (см главу 18)
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            ///метод настраивает службы EFCore для контекста БД

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration["Data:SportStoreProducts:ConnectionString"]));
            //1
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:DefaultConnection"]));

            //2
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connection));


            /// метод AddTransient указывает что каждый раз при реазизации IProductRepository создается обьект FakeProductRepository. подробнее глава 18
            /// по сути это Dependency Injection
            // services.AddTransient<IProductRepository, FakeProductRepository>();

            //заменили фективное хранилеще реальным
            services.AddTransient<IProductRepository, EFProductRepository>();

            ///метод служит указтелем, что для удовлет. запросов к экземплярам Cart должен прим. один и тотже обьект, в данном
            ///случае это коллекция зарегистрированных служб полученных с помощью лямбда выражения.
            /// подробнее описание на стр.283
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            ///данная служба обязательна, и устанавливает что всегда должен применяться один и тот же обьект.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //регистарция хранилища заказов (ORDER) как службу 
            services.AddTransient<IOrderRepository, EFOrderRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        /// <summary>
        /// Метод использует для настройки средств которые получают и обрабатывают HTTP запросы
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            /// Метод расширения, показывает детали исключений в приложении
            app.UseDeveloperExceptionPage();
            /// Добавляет простые сообщения в HTTP ответы - 404 Not Found и т.д.
            app.UseStatusCodePages();
            /// Необходим для обслуживания статических файлов из wwwroot

            ///Метод позволяет системе сеансов автоматически ассоциировать запросы сеансами, когда они проступают от клиента.
            app.UseSession();

            /// Включает Net.Core MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { 
                        controller = "Product", 
                        action = "List" });

                routes.MapRoute(
                   name: null,
                   template: "Page{productPage:int}",
                   defaults: new { 
                        controller = "Product",
                        action = "List", 
                        productPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new {
                        controller = "Product",
                        action = "List",
                        productPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { 
                        controller = "Product", 
                        action = "List", 
                        productPage = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

            });
            SeedData.EnsurePopulated(app);

            //подключение к закрытой папке node_module куда npm какчает bootstrap, обязятельно должна быть после app.UseStaticFiles()
            // если подключать bootstrap не через NMP а через libman, то это не нужно
            //app.UseFileServer(new FileServerOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(env.ContentRootPath, @"node_modules") //строка получения пути к папке
            //    ),
            //    RequestPath = "/node_modules", //это вроде псевдоним для обращения.
            //    EnableDirectoryBrowsing = false
            //});
        }
    }
}
