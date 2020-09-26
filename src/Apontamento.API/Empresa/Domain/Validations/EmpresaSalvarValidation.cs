using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;

namespace Apontamento.App.Empresa.Domain.Validations
{
    public class EmpresaSalvarValidation : EmpresaValidation<EmpresaSalvarCmd>
    {
        public EmpresaSalvarValidation(IEmpresaDapperRepository empresaDapperRepository)
        {
            ValidarId();
            ValidarNome(empresaDapperRepository);
            _empresaDapperRepository = empresaDapperRepository;
        }

        public IEmpresaDapperRepository _empresaDapperRepository { get; }
    }
}
