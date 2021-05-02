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

namespace TFE_Khalifa_Sami_2021
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private const string MyAllowSpecificOrigins = "Access-Control-Allow-Origin";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
             services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
             
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
             services.AddControllers();
             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "TFE_Khalifa_Sami_2021", Version = "v1"});
            });
            
            */
            
            services
                .AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting();
            
            services.AddPooledDbContextFactory<AppDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("myDataBaseConnection"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TFE_Khalifa_Sami_2021 v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            // app.UseCors(MyAllowSpecificOrigins);
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>  endpoints.MapGraphQL() );
            app.UseGraphQLVoyager(new VoyagerOptions{GraphQLEndPoint = "/graphql"});
        }
    }
}