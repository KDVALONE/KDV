using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using N5SportsStore.Models;

namespace N5SportsStore
{
    /// <summary>
    /// Фримен. AspNetCore. Глава 8. N5SportsStore. Онлайн спорт магазин. Максимально приближенный к реальности проект NetCore MVC на NCore 2.1
    /// </summary>
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// Метод настройки распределенных обьектов через внедрение зависимостей (см главу 18)
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            /// метод AddTransient указывает что каждый раз при реазизации IProductRepository создается обьект FakeProductRepository. подробнее глава 18
            /// по сути это Dependency Injection
            services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddMvc();
        }

        /// <summary>
        /// Метод использует для настройки средств которые получают и обрабатывают HTTP запросы
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /// Метод расширения, показывает детали исключений в приложении
            app.UseDeveloperExceptionPage();
            /// Добавляет простые сообщения в HTTP ответы - 404 Not Found и т.д.
            app.UseStatusCodePages();
            /// Необходим для обслуживания статических файлов из wwwroot
            app.UseStaticFiles();
            /// Включает Net.Core MVC
            app.UseMvc(routes => { });
        }
    }
}
