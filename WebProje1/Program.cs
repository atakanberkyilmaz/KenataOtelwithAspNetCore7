using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WebProje1.Models;

internal class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddControllersWithViews();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(x =>
            {
                x.LoginPath = "/Login/GirisYap/";
                x.AccessDeniedPath = "/Login/GirisYap/";
            });
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
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

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute(
            name: "araes",
            pattern: "{area:exists}/{controller=Home}/{ action = Index}"
            );
        app.UseEndpoints(endpoints=>
        { endpoints.MapControllerRoute(
            name:"areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}"
            ); });

        app.Run();
    }
}