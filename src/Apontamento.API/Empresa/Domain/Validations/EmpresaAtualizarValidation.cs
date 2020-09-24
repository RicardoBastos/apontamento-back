using Apontamento.App.Empresa.Domain.Command;

namespace Apontamento.App.Empresa.Domain.Validations
{
    public class EmpresaAtualizarValidation : EmpresaValidation<EmpresaAtualizarCmd>
    {
        public EmpresaAtualizarValidation()
        {
            ValidarId();
            ValidarNome();
        }
    }
}
