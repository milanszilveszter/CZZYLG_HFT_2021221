using CZZYLG_HFT_2021221.Data;
using CZZYLG_HFT_2021221.Endpoint.Services;
using CZZYLG_HFT_2021221.Logic;
using CZZYLG_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CZZYLG_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IStudentLogic, StudentLogic>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ITeacherLogic, TeacherLogic>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IClassroomLogic, ClassroomLogic>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddTransient<SchoolContext, SchoolContext>();

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CZZYLG_HFT_2021221.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CZZYLG_HFT_2021221.Endpoint v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:3917"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
