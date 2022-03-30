namespace Twitter_backend
{
    using System;
    using System.IO;
    using System.Reflection;
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
    using Twitter_backend.Helpers;
    using Twitter_backend.Mappers;
    using Twitter_backend.Repositories;
    using Twitter_backend.Services.Account;
    using Twitter_backend.Services.Comment;
    using Twitter_backend.Services.Tweet;

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

            services.AddScoped(typeof(IItemsRepository<>), typeof(ItemsRepository<>));

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
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TwitterCloneBackend",
                    Version = "v1",
                    Description = "My Twitter Api implementation",

                    Contact = new OpenApiContact
                    {
                        Name = "Anastasia Malkina",
                        Email = "anastmalkina0@gmail.com",
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITweetService, TweetService>();
            services.AddScoped<ICommentService, CommentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            // if the app is under development
            if (env.IsDevelopment())
            {
                // then we display information about the error, if there is an error
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Twitter.Api");
                });
            }

            app.UseHttpsRedirection();

            // adding routing capabilities
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
