using Apontamento.Empresa.Domain.Commands;
using Apontamento.Empresa.Infrastructure.Repository.Interfaces;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.Empresa.Domain.Validations
{
    public class EmpresaValidation : EmpresaValidation<EmpresaAtualizarCommand>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaValidation(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;

            //Database
            ValidarId();
            ValidarNome();

            //Business
            ValidarNomeBanco();
        }

        public void ValidarNomeBanco()
        {
            RuleFor(empresa => empresa)
              .MustAsync(EhEmpresaUnica).WithMessage("Já existe uma empresa com esse nome");
        }


        private async Task<bool> EhEmpresaUnica(EmpresaAtualizarCommand empresaCmd, CancellationToken cancellationToken)
        {
            return await _empresaRepository.GetAsync(empresa => empresa.Id != empresaCmd.Id && empresa.Nome == empresaCmd.Nome) == null;
        }

    }
}
