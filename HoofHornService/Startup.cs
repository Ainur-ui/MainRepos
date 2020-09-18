using HoofHornService.Services;
using HoofHornService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HoofHornService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// �������� ������ ���������� �������.
        /// </summary>
        /// <param name="configuration">������������ ����������.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ����������� ��������.
        /// </summary>
        /// <param name="services">�������.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // ���������� ������������
            services.AddScoped<IWorkerConverter, WorkerConverter>();
            services.AddScoped<ISalaryAdder, SalaryAdder>();

            services.AddControllers();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HoofHornService", Version = "v1" });
            });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        /// <summary>
        /// ���������������� ����������.
        /// </summary>
        /// <param name="app">������ ����������.</param>
        /// <param name="env">���������.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ���������� �������� ��� ������� �������
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Df.Rmp.WebApi v1");
            });
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
