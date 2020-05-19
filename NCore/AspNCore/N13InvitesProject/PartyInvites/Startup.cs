using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PartyInvites.Model;

namespace PartyInvites
{
    public class Startup
    {
        ///Фримен.AspNetCore.Глава 13.N13InvitesProject - тестовое приложение NET CORE в среде VS CODE  

        /// 1 Для полкючения EntityFrameworkCore в файле PartyInvites.csproj <PackageReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="3.1.4"/>
        /// 2 далее dotnet restore  
        /// 3 для миграций и взаимодействие с SQLITE
        /// 4 далее dotnet tool install --global dotnet-ef --version 3.1.0 
        /// 5 далее dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 3.1.4
        /// 6 далее dotnet restore 
        /// 7 dotnet ef migrations add Initial
        /// 8 dotnet ef database update
     
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository,EFRepository>();
            //  services.AddMvc(); //- так было в книжке, но для того чтоб заработало нужно как ниже
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            
            app.UseMvcWithDefaultRoute();

        }
        
    }
}