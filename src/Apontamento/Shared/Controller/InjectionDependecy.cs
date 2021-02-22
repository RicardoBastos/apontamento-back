using Apontamento.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.Empresa.Repository;
using Apontamento.Shared.Domain;
using Apontamento.Shared.Infra;
using Apontamento.Shared.Interfaces.Repository;
using Apontamento.Usuario.Application.Command;
using Apontamento.Usuario.Application.Query;
using Apontamento.Usuario.Application.Handler;
using Apontamento.Usuario.Infrastructure.Repository;
using Apontamento.Usuario.Infrastructure.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Apontamento.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.Projeto.Repository;

namespace Apontamento.Shared.Controller
{
    public static class InjectionDependecy
    {
        public static void ConfigureInjectionDependecy(IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();


            //services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaDapperRepository, EmpresaDapperRepository>();



            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IProjetoDapperRepository, ProjetoDapperRepository>();


            services.AddScoped<IUsuarioDapperRepository, UsuarioDapperRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            services.AddScoped<IRequestHandler<AutenticarCommand, Response<UsuarioQuery>>, UsuarioHandler>();


            //services.AddTransient<INotificationHandler, EmpresaNotificationHandler>();

        }

    }
}
