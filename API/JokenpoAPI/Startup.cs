﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Interfaces;
using Infra.Data;
using Infra.EmailService;
using JokenpoAPI.Consumidores;
using JokenpoAPI.Services;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JokenpoAPI
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

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    );
            });

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<JokenpoContext>(options =>
             options.UseSqlServer(Configuration["connectionstring"])
             );
            // services.AddTransient<IRepositorioBase, RepositorioBase>();
            services.AddTransient<IJokenpoService, JokenpoService>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IPartidaRepositorio, PartidaRepositorio>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEmailService, EmailService>();
            services.AddMassTransit(x =>
            {
                x.AddConsumer<EmailConfirmadoConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri("rabbitmq://localhost"), hostConfigurator =>
                    {
                        hostConfigurator.Username("guest");
                        hostConfigurator.Password("guest");
                    });

                    cfg.ReceiveEndpoint(host, "JokenpoAPI", ep =>
                    {
                        ep.ConfigureConsumer<EmailConfirmadoConsumer>(provider);
                    });
                }));
            });

            services.AddSingleton<IHostedService, BusService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
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
            app.UseCors("CorsPolicy");
            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
