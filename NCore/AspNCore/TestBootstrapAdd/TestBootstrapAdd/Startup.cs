using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace TestBootstrapAdd
{/// <summary>
/// Проверяю устновку NPM и применение файлов из закрытой директории node_module
///ссылка https://wildermuth.com/2017/11/19/ASP-NET-Core-2-0-and-the-End-of-Bower
/// 
/// Способ 1. Установить необходимый путь к директории используюя app.UserFileServer.
/// https://metanit.com/sharp/aspnet5/13.1.php
/// Но есть 2 косяка: 1 - путь в тегах все равно отмечается как не найденный но это не так.
///                   2 - сама идеология обращения к node_module плохой подход, так как все должно быть только в wwwroot/css или wwwroot/css
///                     так же могут возникнуть (читал на форумах) проблемы с отображением у пользователей в каких то случаях.
/// (ПРАВИЛЬНЫЙ) Способ 2. С помощью GULP перенаправлять файлы в каталоги в wwwroot/css или wwwroot/css
/// https://metanit.com/sharp/aspnet5/13.1.php
/// </summary>
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
              // подключаем файлы по умолчанию
              app.UseDefaultFiles();

              #region Способ 1 - подключение к закрытой директории node_module 

              // подключаем статические файлы
              app.UseStaticFiles();

              // добавляем поддержку каталога node_modules !!! Обязательно после app.UseStaticFiles();
              app.UseFileServer(new FileServerOptions()
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(env.ContentRootPath, @"node_modules") //строка получения пути к папке
                    ),
                    RequestPath = "/node_modules", //это вроде псевдоним для обращения.
                    EnableDirectoryBrowsing = false
                });
              #endregion
        }
    }
}
