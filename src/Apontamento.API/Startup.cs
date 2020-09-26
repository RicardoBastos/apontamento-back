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
using FluentValidation.Results;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Usuario.Application.Interface;
using Apontamento.App.Shared.Controller;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using Apontamento.App.Empresa.Application.Interface;
using Apontamento.App.Usuario.Domain.Service;
using Apontamento.App.Usuario.Domain.Command;
using Apontamento.App.Usuario.Domain.Query;
using Apontamento.App.Usuario.Infrastructure.Repository;

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

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);



            services.AddMediatR(Assembly.Load("Apontamento.App"));



            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Apontamento", Version = "v1" });
                opt.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                opt.OperationFilter<AuthenticationRequirementsOperationFilter>();
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ClockSkew = TimeSpan.Zero
               };
           });

            this.ConfigureInjectionDependecy(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apontamento");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
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


            services.AddScoped<IUsuarioDapperRepository, UsuarioDapperRepository>();

            services.AddScoped<IRequestHandler<EmpresaSalvarCmd, ValidationResult>, EmpresaService>();
            services.AddScoped<IRequestHandler<EmpresaAtualizarCmd, ValidationResult>, EmpresaService>();



            services.AddScoped<IRequestHandler<SessionUsuarioCmd, ValidationResult>, UsuarioService>();
            services.AddScoped<IRequestHandler<SessionUsuarioTokenCmd, UsuarioQuery>, UsuarioService>();



            services.AddScoped<IEmpresaApplication, EmpresaApplication>();
            services.AddScoped<ISessionApplication, SessionApplication>();

        }


        public class AuthenticationRequirementsOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Security == null)
                    operation.Security = new List<OpenApiSecurityRequirement>();


                var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    [scheme] = new List<string>()
                });
            }
        }
    }
}
