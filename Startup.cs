using System;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// using Microsoft.OpenApi.Models;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.GraphQL;
using TFE_Khalifa_Sami_2021.Models;
using TFE_Khalifa_Sami_2021.REST.Repositories;

namespace TFE_Khalifa_Sami_2021
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "Access-Control-Allow-Origin";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("myDataBaseConnection"))
            );*/
            
            services.AddPooledDbContextFactory<AppDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("myDataBaseConnection"))
            );

            /*
            //establish CORS authorisation for frontend
            services.AddCors(opt => 
            {
                opt.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    { 
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });  
            */

            /*services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddControllers();*/
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services
                .AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseWebSockets();
            // app.UseCors(MyAllowSpecificOrigins);
            // app.UseAuthorization();
            // app.UseEndpoints(endpoints =>  endpoints.MapControllers() );

            app.UseEndpoints(endpoints =>  endpoints.MapGraphQL() );
            app.UseGraphQLVoyager(new VoyagerOptions{GraphQLEndPoint = "/graphql"});
        }
    }
}