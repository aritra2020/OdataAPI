using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using SampleODataAPI.Models;
using SampleODataAPI.Services;
using SampleODataAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SampleODataAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Added for OData
            services.AddMvcCore(action => action.EnableEndpointRouting = false);
            var connection = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AccountsDB";
            services.AddDbContext<AccountsDbContext>(options => options.UseSqlServer(connection));
            services.AddOData();
            services.AddScoped<IAccount, AccountRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AccountsDbContext accountsDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            accountsDbContext.Database.EnsureCreated();
            //Added for Odata
            //app.UseMvc();
            int? maxtop = 10;
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Expand().Select().Filter().Count().OrderBy().MaxTop(maxtop);
                routeBuilder.MapODataServiceRoute("odata","odata", GetEdmModel());
            });

        }

        //Added for Odata
        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Account>("Accounts");
            return builder.GetEdmModel();
        }
    }
}
