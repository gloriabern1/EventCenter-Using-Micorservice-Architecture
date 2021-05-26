using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloriaEvent.Grpc;
using GloriaEvent.Messages;
using GloriaEvent.web.Models;
using GloriaEvent.web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;

namespace Frontends
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddGrpcClient<Events.EventsClient>(
                o => o.Address = new Uri(Configuration["ApiConfigs:EventComponent:Uri"]));

            services.AddHttpClient<IEventComponentService, EventComponentService>(c =>
            c.BaseAddress = new Uri(Configuration["ApiConfigs:EventComponent:Uri"]));

            services.AddHttpClient<IShoppingBasketComponentService, ShoppingBasketComponentService>(c =>
          c.BaseAddress = new Uri(Configuration["ApiConfigs:ShoppingBasketComponent:Uri"]));

            services.AddSingleton<Settings>();

            var storageAccount = CloudStorageAccount.Parse(Configuration["AzureQueues:ConnectionString"]);
            services.AddRebus(c => c.Transport(t => t.UseAzureStorageQueuesAsOneWayClient(storageAccount))
            .Routing(r => r.TypeBased().Map<PaymentRequestMessage>(Configuration["AzureQueues:QueueName"]))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
