using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Sales_Web_MVC.Data;
using Sales_Web_MVC.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;

namespace Sales_Web_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona o provedor MySQL ao projeto
            builder.Services.AddDbContext<Sales_Web_MVCContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("Sales_Web_MVCContext"), new MySqlServerVersion(new Version(8, 0, 2)),
                mysqlOptions => mysqlOptions.MigrationsAssembly("Sales_Web_MVC")));

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<SalesRecordService>();

            // Adiciona servi�os ao container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Adicionando localidade
            var enUS = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };
            app.UseRequestLocalization(localizationOptions);

            // Configura o pipeline de requisi��o HTTP.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // O valor padr�o do HSTS � 30 dias. Voc� pode querer mudar isso para cen�rios de produ��o, veja https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                // Realiza o seeding dos dados no ambiente de desenvolvimento
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var seedingService = services.GetRequiredService<SeedingService>();
                    seedingService.Seed();
                }

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}


