using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Madina.Data;

namespace Madina
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BaseContext>(options =>
            {
                options.UseSqlite("Filename=database.db");
            });
            services.AddMvc();
            
            services.AddScoped<ActorsService>();
            services.AddScoped<IActorsContext, ActorsContext>();

            services.AddScoped<AwardsService>();
            services.AddScoped<IAwardsContext, AwardsContext>();

            services.AddScoped<DirectorsService>();
            services.AddScoped<IDirectorsContext, DirectorsContext>();

            services.AddScoped<MoviesService>();
            services.AddScoped<IMoviesContext, MoviesContext>();

            services.AddScoped<PostsService>();
            services.AddScoped<IPostsContext, PostsContext>();

            services.AddScoped<ProfileInfoesContext>();
            services.AddScoped<IProfileInfoesContext, ProfileInfoesContext>();

            services.AddScoped<UsersService>();
            services.AddScoped<IUsersContext, UsersContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();

            app.UseAuthentication();
        }
    }
}
