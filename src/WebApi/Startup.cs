using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ViridianCode.ViridianSurvey.DatabaseContext;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;
using ViridianCode.ViridianSurvey.DataRepository.Implementations;
using ViridianCode.ViridianSurvey.DataServices.Interfaces;
using ViridianCode.ViridianSurvey.DataServices.Implementations;

namespace ViridianCode.ViridianSurvey.WebApi
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
            string cs = ConfigurationExtensions.GetConnectionString(this.Configuration, "ViridianSurveysConnection");
            services.AddDbContext<ViridianSurveyContext>(options => options.UseSqlServer(cs));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddMvc();
            services.AddAutoMapper();
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
