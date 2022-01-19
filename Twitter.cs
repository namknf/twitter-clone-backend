namespace Twitter_backend
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Twitter_backend.Models;

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
            services.AddSingleton<IConfiguration>(Configuration);

            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<TweetsContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<CommentsContext>(options => options.UseSqlServer(connection));
            services.AddControllers();

            // services.AddSwaggerGen(c =>
            // {
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Twitter_backend", Version = "v1" });
            // });
            // services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if the app is under development
            if (env.IsDevelopment())
            {
                // then we display information about the error, if there is an error
                app.UseDeveloperExceptionPage();

                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Twitter_backend v1"));
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
