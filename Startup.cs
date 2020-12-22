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
using Microsoft.OpenApi.Models;
using System.Text;
using Newtonsoft.Json;
using AutoMapper;
using LeagueFootball.Helpers;
using Microsoft.EntityFrameworkCore;
using LeagueFootball.Interfaces;
namespace LeagueFootball
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
            
            services.AddDbContext<LeaguesDataContext>(opt=>opt.UseSqlServer(
                Configuration.GetConnectionString("CommanderConnection")));
                
            services.AddControllers().AddNewtonsoftJson(s=>{
            s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            s.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            });
             services.AddScoped<ILeagueService,SqlLeagueRepo>();
             services.AddScoped<ITeamService,SqlTeamRepo>();
             services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "leaguefootball", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "leaguefootball v1"));
            }

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
