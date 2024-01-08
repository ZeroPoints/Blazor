using BlazorAppNet8.Data;
using BlazorAppNet8.Models;
using BlazorAppNet8.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BlazorAppNet8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            //Same for all users and requests.
            builder.Services.AddSingleton<SomeService>();

            //Unique to that users request.
            builder.Services.AddScoped(sp =>
            {
                var model = sp.GetRequiredService<SomeService>();
                return new CascadingValueSource<SomeModel>(model.SomeModel, isFixed: false);
            });


            builder.Services.AddCascadingValue(sp =>
            {
                return sp.GetRequiredService<CascadingValueSource<SomeModel>>();
                //var model = sp.GetRequiredService<CascadingValueSource<SomeModel>>();
                //var source = new CascadingValueSource<SomeModel>(model, isFixed: false);
                //return source;
            });

            builder.Services.AddFluentUIComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}