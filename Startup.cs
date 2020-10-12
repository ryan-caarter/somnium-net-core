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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using somniumAPI.Models;

namespace somniumAPI
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
            services.AddDbContext<ArtistContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
            services.AddControllers();
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
// https://ryancarter@baydreams.scm.azurewebsites.net/baydreams.git
//"Server=tcp:artists-bd-2020.database.windows.net,1433;Database=coreDB;User ID=<username>;Password=<password>;Encrypt=true;Connection Timeout=30;"
//az webapp config connection-string set --resource-group BayDreamsApp --name BayDreams --settings MyDbConnection="Server=tcp:artists-bd-2020.database.windows.net,1433;Database=coreDB;User ID=ryancarter;Password=hPn13kq9.;Encrypt=true;Connection Timeout=30;" --connection-string-type SQLAzure
