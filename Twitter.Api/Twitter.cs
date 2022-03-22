namespace Twitter_backend
{
    using System;
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Twitter_backend.Data;
    using Twitter_backend.Filters;
    using Twitter_backend.Mappers;
    using Twitter_backend.Repositories;
    using Twitter_backend.Services.Account;

    public class Twitter
    {
        public Twitter(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Get connection string from configuration file
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TwitterContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddControllers();
            services.AddCors();

            services.AddScoped(typeof(IAuthRegisterRepository<>), typeof(AuthRegisterRepository<>));

            services.AddAutoMapper(typeof(UserMapper));

            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(mvcConfiguration =>
                    mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Twitter>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Twitter_backend", Version = "v1" });
            });

            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if the app is under development
            if (env.IsDevelopment())
            {
                // then we display information about the error, if there is an error
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Twitter_backend v1"));
            }

            app.UseHttpsRedirection();

            // adding routing capabilities
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            // set addresses to be processed
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
