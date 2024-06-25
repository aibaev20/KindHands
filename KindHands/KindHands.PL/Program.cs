using KindHands.BLL.Interfaces;
using KindHands.BLL.Services;
using KindHands.DAL.Data;
using KindHands.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KindHands.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IOrganisationService, OrganisationService>();
            builder.Services.AddScoped<IVolunteerService, VolunteerService>();

            builder.Services.AddScoped<OrganisationRepository>();
            builder.Services.AddScoped<VolunteerRepository>();

            builder.Services.AddDbContext<KindHandsDbContext>(options =>
            {
                options.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database = KindHands;Trusted_Connection=true;Integrated Security=true;TrustServerCertificate=true");
            });

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
