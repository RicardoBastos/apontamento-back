using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Empresa.Repository;
using Apontamento.App.Shared.Domain;
using Apontamento.App.Shared.Infra;
using Apontamento.App.Shared.Interfaces.Repository;
using Apontamento.App.Usuario.Application.Command;
using Apontamento.App.Usuario.Application.Query;
using Apontamento.App.Usuario.Application.Handler;
using Apontamento.App.Usuario.Infrastructure.Repository;
using Apontamento.App.Usuario.Infrastructure.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Apontamento.App.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.App.Projeto.Repository;

namespace Apontamento.App.Shared.Controller
{
    public static class InjectionDependecy
    {
        public static void ConfigureInjectionDependecy(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaDapperRepository, EmpresaDapperRepository>();



            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IProjetoDapperRepository, ProjetoDapperRepository>();


            services.AddScoped<IUsuarioDapperRepository, UsuarioDapperRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            services.AddScoped<IRequestHandler<AutenticarCommand, Response<UsuarioQuery>>, UsuarioHandler>();

        }

    }
}
