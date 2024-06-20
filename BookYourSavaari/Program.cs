using Microsoft.EntityFrameworkCore;
using BusinessService;
using DataEntity;
using Repository;

namespace BookYourSavaari
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            RepositoryDependancyContainer.Registration(builder.Services);
            ServiceDependancy.Registration(builder.Services);



            var configuration = builder.Configuration;

            var connectionString = configuration.GetConnectionString("weltec");


            builder.Services.AddDbContext<BookYourSavaariDbContext>(options => options.UseSqlServer(connectionString));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
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
