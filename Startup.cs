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
using Microsoft.EntityFrameworkCore;
using BdEntityFramework.Data;
using BdEntityFramework.Data.Repositories;
using BdEntityFramework.Models;

namespace BdEntityFramework
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
            // Register SQLServer 
            services.AddDbContext<SchoolDbContext>(options => 
                options.UseSqlServer(
                    Configuration
                    .GetConnectionString("SchoolDatabase"))
            );

            // Services.
            services.AddScoped<IRepository<Classroom>, Repository<Classroom>>();
            services.AddScoped<IRepository<Instrument>, Repository<Instrument>>();
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            services.AddScoped<IRepository<Subject>, Repository<Subject>>();
            services.AddScoped<IRepository<SubjectClassroom>, Repository<SubjectClassroom>>();
            services.AddScoped<IRepository<Teacher>, Repository<Teacher>>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseMvc();
        }
    }
}
