using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;

namespace Apontamento.App.Empresa.Domain.Validations
{
    public class EmpresaAtualizarValidation : EmpresaValidation<EmpresaAtualizarCmd>
    {
        public EmpresaAtualizarValidation(IEmpresaDapperRepository empresaDapperRepository)
        {
            ValidarId();
            ValidarNome(empresaDapperRepository);
            _empresaDapperRepository = empresaDapperRepository;
        }

        public IEmpresaDapperRepository _empresaDapperRepository { get; }
    }
}
