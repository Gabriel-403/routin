using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using routin.Data;

namespace routin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scoped = host.Services.CreateScope())
            {
                try
                {
                    var dbcontext = scoped.ServiceProvider.GetService<RoutinDbContext>();
                    dbcontext.Database.EnsureDeleted();//启动前删除数据库
                    dbcontext.Database.Migrate();//迁移数据库
                }
                catch (Exception ex)
                {
                    var logger = scoped.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "database migration error");
                    
                }
            }
                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
