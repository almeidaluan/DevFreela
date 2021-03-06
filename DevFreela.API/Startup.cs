using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Controllers;
using DevFreela.API.Filters;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.SaveComment;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetByIdProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Validators;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DevFreela.API
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
            services.Configure<OpeningTime>(Configuration.GetSection("OpeningTime"));

            var connectionString = Configuration.GetConnectionString("DevFreelaCs");
            services.AddDbContext<DevFreelaDbContext>(options => options.UseMySql(connectionString,new MySqlServerVersion(new Version(5, 7,33))));
            //services.AddDbContext<DevFreelaDbContext>(options => options.UseInMemoryDatabase("DevFreela"));
            services.AddScoped<IProjectService,ProjectService>();
            services.AddScoped<ISkillService,SkillService>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            
            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserCreateCommandValidator>()); // nao precisa adicionar outros validators, adicionando um ja entende todo o resto

            services.AddMediatR(typeof(CreateProjectCommand));
            services.AddMediatR(typeof(SaveCommentCommand));
            services.AddMediatR(typeof(StartProjectCommand));
            services.AddMediatR(typeof(FinishProjectCommand));

            services.AddMediatR(typeof(GetByIdProjectQueries));
            services.AddMediatR(typeof(GetAllProjectsQueries));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
