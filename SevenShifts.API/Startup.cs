using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SevenShifts.Application;
using SevenShifts.Application.Contracts;
using SevenShifts.Domain.Contracts;
using SevenShifts.Domain.Entities;
using SevenShifts.Repository.Repositories;

namespace SevenShifts.API
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

            services.AddScoped<IEmployee, SevenShifts.Application.Employee>();
            services.AddScoped<IWageCalculator, BasicWageCalculator>();
            services.AddScoped<IWorkedHourCalculator, SevenShifts.Domain.Entities.WorkedHourCalculator>();
            services.AddScoped<IUserRepository, UserRepository>((x) =>
            {
                return new UserRepository($"{Configuration["SevenShiftsApiDomain"]}{Configuration["SevenShiftsUserApi"]}");
            });
            services.AddScoped<ILocationRepository, LocationRepository>((x) =>
            {
                return new LocationRepository($"{Configuration["SevenShiftsApiDomain"]}{Configuration["SevenShiftsLocationApi"]}");
            });
            services.AddScoped<ITimePunchRepository, TimePunchRepository>((x) =>
            {
                return new TimePunchRepository($"{Configuration["SevenShiftsApiDomain"]}{Configuration["SevenShiftsTimePunchApi"]}");
            });

            services.AddMvcCore()
                    .AddJsonFormatters()
                    .AddApiExplorer()
                    .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
