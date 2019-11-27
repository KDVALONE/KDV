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

namespace N4WorkingWithVisualStudio
{
    /// <summary>
    ///Фримен. AspNetCore. Глава 7. N4WorkingWithVisualStudio. Модульное тестирование. Используем проект из главы 6.v1
    /// </summary>
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //подключение к закрытой папке node_module куда npm какчает bootstrap, обязятельно должна быть после app.UseStaticFiles()
            app.UseFileServer(new FileServerOptions()  
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, @"node_modules") //строка получения пути к папке
                ),
                RequestPath = "/node_modules", //это вроде псевдоним для обращения.
                EnableDirectoryBrowsing = false
            });
        }
    }
}
