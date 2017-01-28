using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.IRepositories;
using Application.UserApp;
using EntityFrameworkCore.Repositories;
using Application;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace MVC
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            RoleMapper.Initialize();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //获取数据库连接字符串
            var sqlConnectionString = Configuration.GetConnectionString("Default");
            //添加数据上下文
            services.AddDbContext<RoleDBContext>(options => options.UseNpgsql(sqlConnectionString));
            //仓储及服务进行依赖注入的实现
            //注意：Asp.Net Core提供的依赖注入拥有三种生命周期模式，由短到长依次为：
            //•Transient ServiceProvider总是创建一个新的服务实例。
            //•Scoped ServiceProvider创建的服务实例由自己保存，（同一次请求）所以同一个ServiceProvider对象提供的服务实例均是同一个对象。
            //•Singleton 始终是同一个实例对象
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();

            services.AddMvc();
           
            //session服务
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //生产环境异常处理
                app.UseExceptionHandler("/Shared/Error");
            }
            //使用静态文件
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions() {
               FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            });

            //请求管道启用session
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });

            SeedData.Initialize(app.ApplicationServices);//初始化数据

            //app.UseMvcWithDefaultRoute();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //项目说明：
            //•MVC
            //Asp.Net Core MVC网站项目。

            //•Application
            //应用服务项目，定义应用服务接口及实现，MVC控制器调用；同时定义接收及返回数据对象（Dto，这里我有可能会省去，直接拿实体往表现层传了……）

            //•Domain
            //主要定义实体、仓储接口等。

            //•EntityFrameworkCore
            //主要是仓储接口的EF Core具体实现

            //•Utility
            //通用项目，定义项目无关的一些公共类库。
            //

        }
    }
}
