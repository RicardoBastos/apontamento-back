using Apontamento.App.Empresa.Domain.Command;

namespace Apontamento.App.Empresa.Domain.Validations
{
    public class EmpresaSalvarValidation : EmpresaValidation<EmpresaSalvarCmd>
    {
        public EmpresaSalvarValidation()
        {
            ValidarId();
            ValidarNome();
        }
    }
}
