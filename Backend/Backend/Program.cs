using ChatAppBackend.Hubs;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            //builder.Services.AddControllers();
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<SmartHomeContext>(options => options.UseInMemoryDatabase("SmartHomeDB"));
            //builder.Services.AddDataProtection();
            //builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5174")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors();
            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SmartHomeHub>("/smartHomeHub");
            });

            app.Run();
        }
    }
}