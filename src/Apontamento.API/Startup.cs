using Apontamento.App.Shared.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using MediatR;
using Apontamento.App.Shared.Interfaces.Repository;
using Apontamento.App.Empresa.Repository;
using System.Data;
using Microsoft.Data.SqlClient;
using Apontamento.App.Empresa.Application;
using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Domain.Service;
using Apontamento.App.Empresa.Application.Interface;
using FluentValidation.Results;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;

namespace Apontamento.API
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

            services.AddDbContext<ApontamentoContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("ApontamentoConnection")));


            services.AddTransient<IDbConnection>((sp) => new SqlConnection(
                Configuration.GetConnectionString("ApontamentoConnection")));

            services.AddCors();

            services.AddMediatR(Assembly.Load("Apontamento.App"));



            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            this.ConfigureInjectionDependecy(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apontamento");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureInjectionDependecy(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaDapperRepository, EmpresaDapperRepository>();

            services.AddScoped<IRequestHandler<EmpresaSalvarCmd, ValidationResult>, EmpresaService>();
            services.AddScoped<IRequestHandler<EmpresaAtualizarCmd, ValidationResult>, EmpresaService>();


            services.AddScoped<IEmpresaApplication, EmpresaApplication>();

        }
    }
}
