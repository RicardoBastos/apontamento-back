using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Projeto.Application.Command;
using Apontamento.App.Projeto.Infrastructure.Repository.Interfaces;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.App.Projeto.Application.Validations
{
    public class ProjetoSalvarValdiation : ProjetoValidation<ProjetoSalvarCommand>
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IEmpresaRepository _empresaRepository;


        public ProjetoSalvarValdiation(IProjetoRepository projetoRepository, IEmpresaRepository empresaRepository)
        {
            _projetoRepository = projetoRepository;
            _empresaRepository = empresaRepository;

            //Database
            ValidarId();
            ValidarNome();
            ValidarEmpresa();


            //Business
            ValidarNomeBanco();
            ValidarEmpresaExiste();
        }

        public void ValidarNomeBanco()
        {
            RuleFor(Projeto => Projeto)
              .MustAsync(EhProjetoUnica).WithMessage("Já existe um Projeto com esse nome");
        }

        public void ValidarEmpresaExiste()
        {
            RuleFor(Projeto => Projeto)
              .MustAsync(ExisteEmpresa).WithMessage("Empresa não encontrada");
        }


        private async Task<bool> EhProjetoUnica(ProjetoSalvarCommand ProjetoCmd, CancellationToken cancellationToken)
        {
            return await _projetoRepository.GetAsync(Projeto => Projeto.Id != ProjetoCmd.Id && Projeto.Nome == ProjetoCmd.Nome) == null;
        }

        private async Task<bool> ExisteEmpresa(ProjetoSalvarCommand ProjetoCmd, CancellationToken cancellationToken)
        {
            return await _empresaRepository.GetAsync(empresa => empresa.Id == ProjetoCmd.EmpresaId) != null;
        }

    }
}
